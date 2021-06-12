using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_LINQ;
using BUS_LINQ;

namespace GUI_LINQ
{
    public partial class FrmLogin : Form
    {
        //List<TaiKhoangDN> TK = new List<TaiKhoangDN>();
        TaiKhoangDN TK = new TaiKhoangDN();
        BUS bus = new BUS();
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text !="" && textBox2.Text != "")
            {
                TK = bus.TaiKhoan(textBox1.Text, textBox2.Text);
                bool quyen = false;
                if(TK == null)
                {
                    MessageBox.Show(" Tài khoản hoặc mật khẩu không chính xác");
                } 
                else
                {
                    
                    GUI frm = new GUI(TK.QuyHang);
                    this.Hide();
                    frm.ShowDialog();
                } 

                textBox1.Clear();
                textBox2.Clear();
            } 
            else
            {
                MessageBox.Show(" Bạn chưa điền đầy đủ thông tin");
            }    
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool chk;
            chk = checkBox1.Checked;
            textBox2.UseSystemPasswordChar = (!chk); 
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
