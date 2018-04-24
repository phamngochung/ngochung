using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if (taiKhoan.Text == "" && matKhau.Text == "")
            {
                button2.Enabled = false;
                button1.Enabled = false;
            }
            ReadSettings();
        }
         SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-RTQ2N2T;Initial Catalog=qlks;Integrated Security=True");
       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (matKhau.Text != "" && matKhau.Text!="")
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnn.Open();
            String sql = "SELECT * FROM users" ;
            int a = 0;
            SqlCommand cm = new SqlCommand(sql, cnn);
            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                if(taiKhoan.Text==rd["tenDN"].ToString() && matKhau.Text==rd["MK"].ToString())
                {
                    a = 1;
                    break;
                }
            }
            if (a == 0)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công");
                Form2 b = new Form2();
                b.Show();
                this.Hide();
                SaveSettings();
            }
            cnn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có thực sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dlr==DialogResult.OK)
                this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void taiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (taiKhoan.Text != "" && matKhau.Text !="")
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void ReadSettings()
        {
            if (Properties.Settings.Default.checkBox1 == true)
            {
                taiKhoan.Text = Properties.Settings.Default.taiKhoan;
                matKhau.Text = Properties.Settings.Default.matKhau;
                checkBox1.Checked = true;
            }
            else
            {
                taiKhoan.Text = "";
                matKhau.Text = "";
                checkBox1.Checked = false;
            }
        }
        private void SaveSettings()
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.taiKhoan = taiKhoan.Text;
                Properties.Settings.Default.matKhau = matKhau.Text;
                Properties.Settings.Default.checkBox1 = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.taiKhoan = taiKhoan.Text;
                Properties.Settings.Default.matKhau = "";
                Properties.Settings.Default.checkBox1 = false;
                Properties.Settings.Default.Save();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 c = new Form3();
            c.Show();
            this.Hide();
        }
    }
}
       

