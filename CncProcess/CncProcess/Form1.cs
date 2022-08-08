using DevExpress.XtraTabbedMdi;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CncProcess
{
    public struct CNC_DATA
    {
        public int Load1;
        public int Load2;
        public int Load3;
        public int Load4;
        public int Rev;
    };


    public struct CNC_INFO
    {
        public int id;
        public int msg;
    };
    public partial class Form1 : Form
    {
        #region 鼠标左键移动窗体

        public const int WM_NCLBUTTONDOWN = 0xa1;

        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]

        public static extern bool ReleaseCapture();

        #endregion

        Charts chartCnc1;
        Charts chartCnc2;
        Charts chartCnc3;
        DataTable cnc1Data;
        DataTable cnc2Data;
        DataTable cnc3Data;


        int cnc_connect = 0;




        int nPage = -1; // 是否打开了页面
        public Form1()
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();

        }
        private void Menu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)

            {

                ReleaseCapture();

                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

            }
        }


        void ReceiveCNCInfo(CNC_INFO info)
        {

            switch (info.id)
            {
                case 1:
                    if (info.msg == 1)
                    {
                        cnc_connect += 1;
                        this.navBarItem4.SmallImage = Image.FromFile(@"D:\wz\code\git\cnc\CncProcess\CncProcess\img\设备状态(Start).png");
                    }
                    break;
                case 2:
                    if (info.msg == 1)
                    {
                        cnc_connect += 1;
                        this.navBarItem5.SmallImage = Image.FromFile(@"E:\wz\code\CncProcess\CncProcess\img\设备状态(Start).png");
                    }
                    break;
                case 3:
                    if (info.msg == 1)
                    {
                        cnc_connect += 1;
                        this.navBarItem6.SmallImage = Image.FromFile(@"E:\wz\code\CncProcess\CncProcess\img\设备状态(Start).png");
                    }
                    break;
            }
        }
        private void quiteMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void maxMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.maxMenuItem.Image = Image.FromFile(@"D:\wz\code\git\cnc\CncProcess\CncProcess\img\放大.png");
            }
            else
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                this.maxMenuItem.Image = Image.FromFile(@"D:\wz\code\git\cnc\CncProcess\CncProcess\img\还原.png");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cnc1Data = ExcelToDatatable(@"E:\wz\code\Data\cnc_1.xls", "sheet1", true);
            //cnc2Data = ExcelToDatatable(@"E:\wz\code\Data\cnc_2.xls", "sheet1", true);
            //cnc3Data = ExcelToDatatable(@"E:\wz\code\Data\cnc_3.xls", "sheet1", true);
        }

        public void setChartInfo(ref Charts ch, string strCNC, DataTable dt, int Group)
        {
            Charts chart = new Charts();
            chart.MdiParent = this;
            chart.WindowState = FormWindowState.Maximized;
            chart.Show();
            xtraTabbedMdiManager1.Pages[nPage].Text = strCNC;
            ch = chart;
            ch.setLog(Group);


            // 绑定与主窗口的事件委托
            CncHandl cnch = ch.getCNChandle();

            cnch.CNCEvent += new CncHandl.CNCToControl(this.ReceiveCNCInfo);
        }

        #region 菜单栏点击事件
        public void OpenMDIWindow(String ChildTypeString, Object[] args)
        {
            if (String.IsNullOrWhiteSpace(ChildTypeString))
                return;

            if (ContainMDIChild(ChildTypeString))
                return;

            switch (ChildTypeString)
            {
                case "cnc1":
                    setChartInfo(ref chartCnc1, "cnc1", cnc1Data, 1);
                    break;
                case "cnc2":
                    setChartInfo(ref chartCnc2, "cnc2", cnc2Data, 2);
                    break;
                case "cnc3":
                    setChartInfo(ref chartCnc3, "cnc3", cnc3Data, 3);
                    break;

                case "cnc1_control":
                    Charts cnc_Control1 = new Charts();
                    cnc_Control1.MdiParent = this;
                    cnc_Control1.WindowState = FormWindowState.Maximized;
                    cnc_Control1.Show();
                    xtraTabbedMdiManager1.Pages[nPage].Text = "CNC[1]数据管理";
                    break;
                default:
                    break;

            }
        }

        //判断MDI中是否已存在当前窗体
        private Boolean ContainMDIChild(String ChildTypeString)
        {
            int nXtr = 0;
            foreach (XtraMdiTabPage page in xtraTabbedMdiManager1.Pages)
            {

                if (page.Text == ChildTypeString)
                {
                    xtraTabbedMdiManager1.SelectedPage = page;
                    return true;
                }
                nXtr++;
            }
            nPage = nXtr;
            return false;
        }
        #endregion

        #region Excel更新图表数据点

        private void AddNewDataPoint(DataTable cncData, Charts chart, ref int index)
        {
            if (cncData.Rows.Count == 0 || nPage < 0 || chart == null)
                return;
            double L1 = Convert.ToDouble(cncData.Rows[index][1].ToString());

            double L2 = Convert.ToDouble(cncData.Rows[index][2].ToString());

            double L3 = Convert.ToDouble(cncData.Rows[index][3].ToString());

            double L4 = Convert.ToDouble(cncData.Rows[index][4].ToString());

            double R1 = Convert.ToDouble(cncData.Rows[index][0].ToString());
            index += 1;
            if (index == cncData.Rows.Count)
            {
                index = 0;
            }

            chart.upPointData(L1, L2, L3, L4, R1);
        }

        #endregion


        #region 机床数据更新 图表数据点

        public void startCncCharts(Charts chart)
        {
            chart.upCncChart();
        }

        #endregion
        private void navBarControl1_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            if (e.Link.Item.Tag != null)
            {
                try
                {
                    OpenMDIWindow(e.Link.Item.Tag.ToString(), null);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #region DataTable结构体

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


        #endregion

        #region 进行DataTabel数据写入SQL
        private void CncDataToDB(DataTable cncData, int orderId, string dbTable)
        {
            if (cncData == null)
                return;

            SqlHelper db = new SqlHelper();
            DataTable dt = GetTableSchema();
            for (int i = 0; i < cncData.Rows.Count; i++)
            {
                DataRow r = dt.NewRow();
                //r[0] = i + 1;
                r[1] = orderId;
                r[2] = i + 1;
                r[3] = DateTime.Now;
                r[4] = Convert.ToInt32(cncData.Rows[i][0].ToString());
                r[5] = Convert.ToInt32(cncData.Rows[i][1].ToString());
                r[6] = Convert.ToInt32(cncData.Rows[i][2].ToString());
                r[7] = Convert.ToInt32(cncData.Rows[i][3].ToString());
                r[8] = Convert.ToInt32(cncData.Rows[i][4].ToString());
                dt.Rows.Add(r);
            }
            db.BulkToDB(dt);
        }
        #endregion


        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Enabled = timer1.Enabled ? false : true;

            //startCncCharts(chartCnc1);
            //startCncCharts(chartCnc2);
            //string sqlStr = "SELECT * FROM dbo.Device_Info";
            //DataSet ce = db.Query(sqlStr);
            //string xxx = Convert.ToString(ce.Tables[0].Rows[2]["Name"]);


            //SqlHelper db = new SqlHelper();
            //db.CheckTabInDB();

            //AlgModel alg = new AlgModel();
            //alg.test();




            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //var task1 = Task.Run(() => CncDataToDB(cnc1Data, 1, "T1"));
            //var task2 = Task.Run(() => CncDataToDB(cnc2Data, 2, "T1"));
            //var task3 = Task.Run(() => CncDataToDB(cnc3Data, 3, "T1"));

            //////CncDataToDB(cnc2Data, 2, "T0729");
            //////CncDataToDB(cnc3Data, 3, "T0729");
            //sw.Stop();
            //string cc = string.Format("ElaspedMilliseconds {0}", sw.ElapsedMilliseconds);
            //int x = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //startCncCharts(chartCnc1);
            //startCncCharts(chartCnc2);
            //startCncCharts(chartCnc3);
        }
    }
    #region 顶级菜单设置
    public class MyRenderer : ToolStripProfessionalRenderer
    {
        public MyRenderer() : base(new CustomToolStripColorTable()) { }
    }

    public class CustomToolStripColorTable : ProfessionalColorTable
    {
        /// <summary>
        /// 主菜单项被点击后，展开的下拉菜单面板的边框
        /// </summary>
        //public override Color MenuBorder
        //{
        //    get
        //    {
        //        return Color.FromArgb(56, 58, 59);
        //    }
        //}
        /// <summary>
        /// 鼠标移动到菜单项（主菜单及下拉菜单）时，下拉菜单项的边框
        /// </summary>
        public override Color MenuItemBorder
        {
            get
            {
                return Color.FromArgb(56, 58, 59);
            }
        }
        #region 顶级菜单被选中背景颜色
        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Color.FromArgb(56, 58, 59);
                //return Color.Transparent;
            }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                //return Color.FromArgb(56, 58, 59);
                return Color.Transparent;
            }
        }
        #endregion
        #region 顶级菜单被按下是，菜单项背景色
        //public override Color MenuItemPressedGradientBegin
        //{
        //    get
        //    {
        //        return Color.FromArgb(56, 58, 59);
        //    }
        //}
        //public override Color MenuItemPressedGradientMiddle
        //{
        //    get
        //    {
        //        return Color.FromArgb(37, 37, 37);
        //    }
        //}
        //public override Color MenuItemPressedGradientEnd
        //{
        //    get
        //    {
        //        return Color.Black;
        //    }
        //}
        //#endregion
        ///// <summary>
        ///// 菜单项被选中时的颜色
        ///// </summary>
        //public override Color MenuItemSelected
        //{
        //    get
        //    {
        //        return Color.FromArgb(37, 37, 37);
        //    }
        //}
        //#region 下拉菜单面板背景设置（不包括下拉菜单项）
        ////下拉菜单面板背景一共分为2个部分，左边为图像区域，右侧为文本区域，需要分别设置
        ////ToolStripDropDownBackground设置文本部分的背景色
        //public override Color ToolStripDropDownBackground
        //{
        //    get
        //    {
        //        return Color.Black;
        //    }
        //}
        ////以ImageMarginGradient开头的3个设置的是图像部分的背景色，begin->end是从左到右的顺序
        //public override Color ImageMarginGradientBegin
        //{
        //    get
        //    {
        //        return Color.Black;
        //    }
        //}
        //public override Color ImageMarginGradientMiddle
        //{
        //    get
        //    {
        //        return Color.Black;
        //    }
        //}
        //public override Color ImageMarginGradientEnd
        //{
        //    get
        //    {
        //        return Color.Black;
        //    }
        //}
        #endregion
    }
    #endregion
}
