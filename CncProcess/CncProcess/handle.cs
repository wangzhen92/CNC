using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CncProcess
{
    public partial class CncHandl : Form
    {
        public delegate void CNCToControl(CNC_INFO msg);

        public event CNCToControl CNCEvent;


        CNC_INFO info;
        CNC_DATA data;

        List<CNC_DATA> listDatas = new List<CNC_DATA>();
        public ushort h;
        public void ToControlInfo(CNC_INFO msg)
        {
            if (CNCEvent != null)
            {
                CNCEvent(msg);
            }
        }

        public CncHandl()
        {
            InitializeComponent();
            info.id = 0;
            info.msg = 0;
        }
        public void setTitle(String title)
        {
            this.Text = title;
        }


        public void setCncInfo(int group)
        {
            info.id = group;
        }


        private void btnConc_Click(object sender, EventArgs e)
        {
            string ip = txtIp.Text;
            string port = txtPort.Text;
            string timeout = txtTimeOut.Text;
            ToControlInfo(info);
            int ret = Fanuc.cnc_allclibhndl3(ip, Convert.ToUInt16(port), Convert.ToInt32(timeout), out h);
            if (ret == Fanuc.EW_OK)
            {
                MessageBox.Show("连接成功！");
                info.msg = 1;
                ToControlInfo(info);
            }
            else
            {
                MessageBox.Show(ret + "");


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ret = Fanuc.cnc_freelibhndl(h);
            if (ret == Fanuc.EW_OK)
            {
                MessageBox.Show("断开连接成功！");
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string timeout = textBox1.Text;
            int ret = Fanuc.cnc_settimeout(h, Convert.ToInt32(timeout));
            if (ret == Fanuc.EW_OK)
            {
                MessageBox.Show("设置超时成功！");
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }

        Fanuc.ODBACT pindle = new Focas1.ODBACT();
        public void get_pindle()//获取主轴的速度
        {
            short ret = Fanuc.cnc_acts(h, pindle);
            if (ret == 0)
            {
                string rev = pindle.data.ToString();
                data.Rev = Convert.ToInt32(rev);
            }
            else
            {
                MessageBox.Show(ret + "");
            }
        }


        Fanuc.ODBSVLOAD sv = new Focas1.ODBSVLOAD();
        Fanuc.ODBSPLOAD sp = new Focas1.ODBSPLOAD();
        public void get_load()//主，伺服轴的加载计//测试成功
        {
            short a = 6;//伺服轴的数量
            short ret = Fanuc.cnc_rdsvmeter(h, ref a, sv);
            short type = -1;//1朱轴压力,-1俩者都有,0主轴监控速度表
            short ret2 = Fanuc.cnc_rdspmeter(h, type, ref a, sp);
            if (ret == 0 && ret2 == 0)
            {
                //string x1 = string.Format("伺服的加载值：{0} {1} {2}", sv.svload1.data, sv.svload2.data, sv.svload3.data);
                data.Load2 = Convert.ToInt32(sv.svload1.data);
                data.Load3 = Convert.ToInt32(sv.svload2.data);
                data.Load4 = Convert.ToInt32(sv.svload3.data);
                //string x2 = string.Format("主轴的加载值：{0}", sp.spload1.spload.data);
                data.Load1 = Convert.ToInt32(sp.spload1.spload.data);
            }
            else
            {
                MessageBox.Show(ret + "");
            }

        }

        public CNC_DATA getCncData()
        {
            get_load();
            get_pindle();
            listDatas.Add(data);

            if (listDatas.Count >= 100)
            {
                CncDataToDB();
                listDatas.Clear();


            }


            return data;
        }

        public static DataTable GetTableSchema()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("ID",typeof(int)),
                new DataColumn("devie_id",typeof(int)),
                new DataColumn("order_id",typeof(int)),
                new DataColumn("Data",typeof(DateTime)),
                new DataColumn("sprev",typeof(int)),
                new DataColumn("spload",typeof(int)),
                new DataColumn("spload1",typeof(int)),
                new DataColumn("spload2",typeof(int)),
                new DataColumn("spload3",typeof(int)),

            });
            return dt;
        }

        private void CncDataToDB()
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = GetTableSchema();
            for (int i = 0; i < listDatas.Count; i++)
            {
                DataRow r = dt.NewRow();
                //r[0] = i + 1;
                r[1] = info.id;
                r[2] = i + 1;
                r[3] = DateTime.Now;
                r[4] = listDatas[i].Rev;
                r[5] = listDatas[i].Load1;
                r[6] = listDatas[i].Load2;
                r[7] = listDatas[i].Load3;
                r[8] = listDatas[i].Load4;
                dt.Rows.Add(r);
            }
            db.CheckTabInDB();
            db.BulkToDB(dt);
        }

    }
}
