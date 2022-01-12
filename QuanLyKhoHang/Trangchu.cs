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
    public partial class Trangchu : Form
    {
        StartupBLL startupBLL = new StartupBLL();

        public Trangchu()
        {
            InitializeComponent();
        }

        private void quanLyNhanVientoolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new Nhanvien();
            f.FormClosed += (s, args) => this.Show();
            f.Show();
        }

        private void quanLySanPhamToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new Quanlysanpham();
            f.FormClosed += (s, args) => this.Show();
            f.Show();
        }

        private void sQLXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                startupBLL.createXML();
                MessageBox.Show("Chuyển đổi thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chuyển đổi thất bại!\n" + ex);
            }
        }

        private void xMLSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                startupBLL.updateSQL();
                MessageBox.Show("Chuyển đổi thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chuyển đổi thất bại!\n" + ex);
            }
        }

        private void quanLyNhapHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new Quanlynhapkho();
            f.FormClosed += (s, args) => this.Show();
            f.Show();
        }

        private void quanLyXuatHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new Quanlyxuatkho();
            f.FormClosed += (s, args) => this.Show();
            f.Show();
        }

        private void quanLyNhomHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new Nhomhang();
            f.Closed += (s, args) => this.Show();
            f.Show();
        }
    }
}
