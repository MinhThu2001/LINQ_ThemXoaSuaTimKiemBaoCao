using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_LINQ
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
           
        }

        private void BaoCao_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetBaoCao.BaoCaoDKLCT' table. You can move, or remove it, as needed.
            this.BaoCaoDKLCTTableAdapter.Fill(this.DataSetBaoCao.BaoCaoDKLCT, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
