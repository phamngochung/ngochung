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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            cnn.Open();
            ketnoicsdl();

        }
        SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-RTQ2N2T;Initial Catalog=qlks;Integrated Security=True");
        private void ketnoicsdl()
        {
            string sql = "select Ho_ten as 'Họ và Tên', CMND as 'Chứng minh nhân dân', Đia_chi as 'Địa chỉ', Loai_phong as 'Loại phòng', So_phong as 'Số phòng', Ngay_thue as 'Ngày thuê', Ngay_tra as 'Ngày trả', Thanh_tien as 'Thành tiền', Ghi_chu as 'Ghi chú' from qlks";  // lay het du lieu trong bang books
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                MessageBox.Show(" vui lòng nhập đầy đủ", "Có lỗi xảy ra !!!");
            }
            else
            {
                cnn.Open();
                string query = "INSERT INTO qlks (Ho_ten,CMND, Đia_chi, Loai_phong, Ngay_thue, Ngay_tra, So_phong ) VALUES('" + textBox7.Text + "','" + textBox9.Text + "', '" + textBox8.Text + "' ,'" + comboBox2.Text + "' , '" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox1.Text + "' )";
                SqlCommand sqlCommand = new SqlCommand(query, cnn);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    DialogResult dlr = MessageBox.Show("Đã thêm dữ liệu","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    if (dlr == DialogResult.OK)
                        ketnoicsdl(); 
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi");
                }
                cnn.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                MessageBox.Show(" vui lòng nhập đầy đủ", "Có lỗi xảy ra !!!");
            }
            else
            {
                cnn.Open();
                string query = "DELETE FROM  qlks where CMND='" + textBox9.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(query, cnn);
                sqlCommand.ExecuteNonQuery();
                DialogResult dlr = MessageBox.Show("Đã xóa dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dlr == DialogResult.OK)
                    ketnoicsdl(); 
                cnn.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                MessageBox.Show(" vui lòng nhập đầy đủ", "Có lỗi xảy ra !!!");
            }
            else
            {
                cnn.Open();
                string query = "INSERT INTO qlks (Ho_ten, CMND, Đia_chi, Loai_phong, Ngay_thue, Ngay_tra, So_phong,Ghi_chu) VALUES('" + textBox7.Text + "', '" + textBox9.Text + "', '" + textBox8.Text + "' ,'" + comboBox2.Text + "' , '" + textBox2.Text + "', '" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox10.Text + "')";
                SqlCommand sqlCommand = new SqlCommand(query, cnn);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    DialogResult dlr = MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dlr == DialogResult.OK)
                        ketnoicsdl();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi");
                }
                cnn.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

