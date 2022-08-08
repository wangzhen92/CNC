using DevExpress.Charts.Model;
using DevExpress.XtraCharts;
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
    public partial class Charts : Form
    {

        int Group_ID = 0; //标识 1:CNC1 2:CNC2 3:CNC3

        int row = 0;

        int rowMax = 2000;


        double yLoadMax = 300;
        double yLoadMin = -20;


        double xLoadMax = 200;
        double xLoadMin = 0;



        double yRevMax = 4000;
        double yRevMin = -500;

        double xRevMax = 200;
        double xRevMin = 0;


        DevExpress.XtraCharts.Series L1;
        DevExpress.XtraCharts.Series L2;
        DevExpress.XtraCharts.Series L3;
        DevExpress.XtraCharts.Series L4;

        DevExpress.XtraCharts.Series R1;

        XYDiagram diagram1;
        XYDiagram diagram2;
        CncHandl fHandl;
        public Charts()
        {
            InitializeComponent();
            L1 = chartControl1.Series[0];
            L2 = chartControl1.Series[1];
            L3 = chartControl1.Series[2];
            L4 = chartControl1.Series[3];

            R1 = chartControl2.Series[0];

            diagram1 = chartControl1.Diagram as XYDiagram;
            diagram2 = chartControl2.Diagram as XYDiagram;
            diagram1.AxisY.WholeRange.SetMinMaxValues(yLoadMin, yLoadMax);


            diagram1.AxisX.VisualRange.SetMinMaxValues(xLoadMin, xLoadMax);




            diagram2.AxisY.WholeRange.SetMinMaxValues(yRevMin, yRevMax);

            diagram2.AxisX.VisualRange.SetMinMaxValues(xRevMin, xRevMax);

        }
        public void setLog(int group)
        {
            Group_ID = group;

            fHandl = new CncHandl();
            fHandl.TopLevel = false;
            this.panel1.Controls.Add(fHandl);
            fHandl.Location = new System.Drawing.Point(0, 0);
            fHandl.Show();
            fHandl.setCncInfo(group);

            DevDate devData = new DevDate();
            devData.TopLevel = false;
            this.panel1.Controls.Add(devData);
            devData.Location = new System.Drawing.Point(0, fHandl.Location.Y + fHandl.Height + 2);
            devData.Show();
           
            //f2.Show();

            ////在主窗体panel中添加子窗体f3
            //Form3 f3 = new Form3();
            //f3.TopLevel = false;
            //panel1.Controls.Add(f3);
            
            //f3.Show();



        }


        public CncHandl getCNChandle() {
            return fHandl;
        }

        public void setRowMax(int nMax)
        {
            rowMax = nMax;
            diagram1.AxisX.WholeRange.SetMinMaxValues(xLoadMin, rowMax);
            diagram2.AxisX.WholeRange.SetMinMaxValues(xLoadMin, rowMax);

        }
        public void upPointData(double y1, double y2, double y3, double y4, double r1)
        {
            //添加新点
            row += 1;

            L1.Points.Add(new SeriesPoint(row, y1));
            L2.Points.Add(new SeriesPoint(row, y2));
            L3.Points.Add(new SeriesPoint(row, y3));
            L4.Points.Add(new SeriesPoint(row, y4));


            R1.Points.Add(new SeriesPoint(row, r1));

            int currentMax = (int)Convert.ToDouble(diagram1.AxisX.VisualRange.MaxValue.ToString());
            int currentMin = (int)Convert.ToDouble(diagram1.AxisX.VisualRange.MinValue.ToString());

            if (row >= currentMax)
            {
                diagram1.AxisX.VisualRange.SetMinMaxValues(row - 100, row + 100);
                diagram2.AxisX.VisualRange.SetMinMaxValues(row - 100, row + 100);
            }
            if (row == rowMax)
            {
                row = 0;
                DataClear();
                diagram1.AxisX.VisualRange.SetMinMaxValues(row, row + 100);
                diagram2.AxisX.VisualRange.SetMinMaxValues(row, row + 100);
            }


        }

        
        public void upCncChart() {
            CNC_DATA cd = fHandl.getCncData();
            upPointData(cd.Load1, cd.Load2, cd.Load3, cd.Load4, cd.Rev);
        }

        public void DataClear()
        {
            L1.Points.Clear();
            L2.Points.Clear();
            L3.Points.Clear();
            L4.Points.Clear();
            R1.Points.Clear();

            //chartControl1.Series.Clear();
            //chartControl2.Series.Clear();
        }
    }
}
