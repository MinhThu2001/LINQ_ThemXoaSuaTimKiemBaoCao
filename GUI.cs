using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_LINQ;
using DAL_LINQ;

namespace GUI_LINQ
{
    public partial class GUI : Form
    {
        BUS bus = new BUS();
        int stt;
        bool quye = false;
        public GUI()
        {
            InitializeComponent();
        }
        public GUI(bool q)
        {
            InitializeComponent();
            this.quye = q;
        }

        public bool Kiemtra()
        {
            try
            {
                _ = comboBox1.Text != "";
                _ = comboBox2.Text != "";
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        private void GUI_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bus.HienThi();
            DSCBB();
        }
        public void DSCBB()
        {
            foreach(HOTENDK a in bus.DSTen())
            {
                comboBox2.Items.Add(a.HoTenDK1);
            }
            comboBox1.Items.Add("Bị bệnh");
            comboBox1.Items.Add("Đi họp");
            comboBox1.Items.Add("Đi học");
            comboBox1.Items.Add("Lý do khác");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(quye)
            {
                if (Kiemtra())
                {
                    DKLichCT tb = new DKLichCT();
                    tb.STT = dataGridView1.Rows.Count + 1;
                    tb.NgayBD = dateTimePicker1.Value.Date;
                    tb.NgayKT = dateTimePicker2.Value.Date;
                    tb.LyDo = comboBox1.Text;
                    tb.HoTen = comboBox2.Text;
                    tb.DienGiai = richTextBox1.Text;
                    if (bus.Them(tb))
                    {
                        MessageBox.Show(" Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm 'KHÔNG' thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin");
                }
                richTextBox1.Clear();
                dataGridView1.DataSource = bus.HienThi();
            }
            else
            {
                MessageBox.Show(" Bạn không có quyền thêm", "Thông Báo", MessageBoxButtons.YesNo);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(quye)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    int tv = Int32.Parse(row.Cells[0].Value.ToString());
                    if (bus.Xoa(tv))
                    {
                        MessageBox.Show("Xóa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa 'KHÔNG' thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn dòng cần xóa");
                }
                richTextBox1.Clear();
                dataGridView1.DataSource = bus.HienThi();
            }  
           else
            {
                MessageBox.Show(" Bận không có quyền xóa", "Thông Báo", MessageBoxButtons.YesNo);
            }    
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(quye)
            {
                DKLichCT tb = new DKLichCT();
                tb.STT = stt;
                tb.NgayBD = dateTimePicker1.Value.Date;
                tb.NgayKT = dateTimePicker2.Value.Date;
                tb.LyDo = comboBox1.Text;
                tb.HoTen = comboBox2.Text;
                tb.DienGiai = richTextBox1.Text;
                if (bus.Sua(tb))
                {
                    MessageBox.Show("Sửa thành công");
                }
                else
                {
                    MessageBox.Show("Sửa 'KHÔNG' thành công");
                }
                richTextBox1.Clear();
                dataGridView1.DataSource = bus.HienThi();
            }  
            else
            {
                MessageBox.Show(" Bạn không có quyền sửa", "Thông Báo", MessageBoxButtons.YesNo);
            }    
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCellAddress.X == 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                stt = Int32.Parse(row.Cells[0].Value.ToString());
                dateTimePicker1.Text = row.Cells[1].Value.ToString();
                dateTimePicker2.Text = row.Cells[2].Value.ToString();
                comboBox1.Text = row.Cells[3].Value.ToString();
                comboBox2.Text = row.Cells[4].Value.ToString();
                richTextBox1.Text = row.Cells[5].Value.ToString();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bus.TimKiem(comboBox2.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(quye)
            {
                Report frm = new Report();
                frm.ShowDialog();
            }    
            else
            {
                MessageBox.Show(" Bạn không có quyền xem báo cáo", "Thông Báo", MessageBoxButtons.YesNo);
            }    
            
        }
    }
}
