using QuanLyKhoHang.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang
{
    public partial class Dangnhap : Form
    {
        DangnhapBLL dangnhapBLL = new DangnhapBLL();
        tkxml fileXML = new tkxml();
        StartupBLL startupBLL = new StartupBLL();

        public Dangnhap()
        {
            InitializeComponent();
        }

        private void button_dangnhap_Click(object sender, EventArgs e)
        {
            if (txt_tendn.Text.Equals("") || txt_matkhau.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tendn.Focus();
            }
            else
            {
                if (dangnhapBLL.loginExistenceCheck("taikhoan.xml", txt_tendn.Text, txt_matkhau.Text) == true)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    this.Hide();
                    Trangchu trangchu = new Trangchu();
                    trangchu.Closed += (s, args) => this.Close();
                    trangchu.Show();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_matkhau.Text = "";
                    txt_tendn.Text = "";
                    txt_tendn.Focus();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
