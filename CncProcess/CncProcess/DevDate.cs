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
    public partial class DevDate : Form
    {
        public DevDate()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 获取当前选择日期
            int wek = (int)this.dateEdit1.DateTime.DayOfWeek;
        }

        private void DevDate_Load(object sender, EventArgs e)
        {
            //本周一
            var thisWeekBengin = DateTime.Now.AddDays(0 - Convert.ToInt16(DateTime.Now.DayOfWeek) + 1);
            //本周日
            var thisWeekEnd = DateTime.Now.AddDays(6 - Convert.ToInt16(DateTime.Now.DayOfWeek) + 1);


            this.dateEdit1.Properties.MinValue = thisWeekBengin;
            this.dateEdit1.Properties.MaxValue = thisWeekEnd;
        }
    }
}
