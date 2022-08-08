using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CncProcess
{
    public class AlgModel
    {

        int nStart = 0;  // 起始点状态变化
        List<int> ListCheck = new List<int>(); //起始点数组

        // 算法设置
        int nExtent = 20;  //起始间隔
        int m_nRevDNL = 100; //误差
        int m_nLoadDNL = 20; //误差

        string sFile; // 文件名

        DataTable m_DtCNC = new DataTable(); //模板数据

        List<CNC_DATA> m_LtCNC = new List<CNC_DATA>();




        public AlgModel()
        {
            //cncData = ExcelHelper.ExcelToDataTable(@"D:\wz\code\Data\cnc_1.xls", "sheet1", true);
        }




        #region 获取本地模板数据
        public DataTable getModelDataTbale()
        {
            m_DtCNC = ExcelHelper.ExcelToDataTable(sFile, "sheet1", true);
            return m_DtCNC;
        }
        #endregion


        #region 创建模板
        public void RegisterModel(CNC_DATA cncdata)
        {
            checkStart(cncdata.Rev);

            //string str5 = Application.StartupPath;
        }


        public void checkStart(int data)
        {
            ListCheck.Add(data);
            if (data > 0)
            {
                ListCheck.Clear();
            }
            if (ListCheck.Count == nExtent)
            {
                nStart += 1;
            }
        }

        //1.获取模板数据
        //2.进行存入模板库里面
        public void CreatModelData(CNC_DATA data)
        {
            if (nStart == 1)
            {
                m_LtCNC.Add(data);
            }
            if (nStart == 2 && m_LtCNC.Count > 0)
            {

                ////把DataTable写入到excel文件中
                int writeCount = ExcelHelper.DataTableToExcel(sFile, ListToDataTable(m_LtCNC), "MySheet", true);

                nStart = 0;
                m_LtCNC.Clear();
            }
        }
        #endregion

        #region List转DataTbale

        public DataTable ListToDataTable(List<CNC_DATA> datas)
        {
            DataTable dt = ExcelHelper.CreateDataTable();
            for (int i = 0; i < datas.Count; i++)
            {
                DataRow newRow = dt.NewRow();
                //为新的一行填充数据
                newRow["sprev"] = datas[i].Rev;
                newRow["spload1"] = datas[i].Load1;
                newRow["spload2"] = datas[i].Load2;
                newRow["spload3"] = datas[i].Load3;
                newRow["spload4"] = datas[i].Load4;
                dt.Rows.Add(newRow);
            }
            return dt;
        }
        #endregion

        #region 进行模板对比
        // 0 代表正常
        //-1 代表数据为空
        // 1 代表有出入
        public int ComparisonChartData(CNC_DATA data, int nIndex)
        {
            int DNL = 0;
            if (m_DtCNC == null || m_DtCNC.Rows.Count == 0)
                return -1;
            int R1 = Convert.ToInt32(m_DtCNC.Rows[nIndex][0].ToString());
            DNL = Math.Abs(R1 - data.Rev);
            if (DNL >= m_nRevDNL)
            {
                return -1;
            }

            int L1 = Convert.ToInt32(m_DtCNC.Rows[nIndex][1].ToString());

            DNL = Math.Abs(L1 - data.Load1);
            if (DNL >= m_nLoadDNL)
            {
                return -1;
            }

            int L2 = Convert.ToInt32(m_DtCNC.Rows[nIndex][2].ToString());
            DNL = Math.Abs(L2 - data.Load2);
            if (DNL >= m_nLoadDNL)
            {
                return -1;
            }

            int L3 = Convert.ToInt32(m_DtCNC.Rows[nIndex][3].ToString());
            DNL = Math.Abs(L3 - data.Load3);
            if (DNL >= m_nLoadDNL)
            {
                return -1;
            }

            int L4 = Convert.ToInt32(m_DtCNC.Rows[nIndex][4].ToString());

            DNL = Math.Abs(L4 - data.Load4);
            if (DNL >= m_nLoadDNL)
            {
                return -1;
            }
            return 0;
        }
        #endregion
    }
}
