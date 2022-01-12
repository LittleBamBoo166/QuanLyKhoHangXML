using QuanLyKhoHang.BLL;
using QuanLyKhoHang.DTO;
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
    public partial class Nhomhang : Form
    {
        tkxml fileXML = new tkxml();
        NhomhangBLL nhomhangBLL = new NhomhangBLL();
        public int current = 0;
        public int maxRow = 0;

        public Nhomhang()
        {
            InitializeComponent();
        }

        public void showData()
        {
            DataTable dt = new DataTable();
            dt = fileXML.HienThi("nhomhang.xml");
            dataGridView1.DataSource = dt;
            maxRow = dataGridView1.RowCount - 1;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            txt_manhomhang.Text = "";
            txt_manhomhang.Text = "";
            txt_ghichu.Text = "";
            txt_manhomhang.Focus();
        }

        private void Nhomhang_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (nhomhangBLL.cateIDCheck(txt_manhomhang.Text) == true)
            {
                MessageBox.Show("Mã nhóm hàng đã tồn tại.");
            }
            else
            {
                NhomhangDTO nhomhangDTO = new NhomhangDTO();
                nhomhangDTO.Manhomhang = txt_manhomhang.Text;
                nhomhangDTO.Tennhomhang = txt_tennhomhang.Text;
                nhomhangDTO.Ghichu = txt_ghichu.Text;
                nhomhangBLL.addCate(nhomhangDTO);
                showData();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            NhomhangDTO nhomhangDTO = new NhomhangDTO();
            nhomhangDTO.Manhomhang = txt_manhomhang.Text;
            nhomhangDTO.Tennhomhang = txt_tennhomhang.Text;
            nhomhangDTO.Ghichu = txt_ghichu.Text;
            nhomhangBLL.editCate(nhomhangDTO);
            MessageBox.Show("Thành công!");
            showData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            NhomhangDTO nhomhangDTO = new NhomhangDTO();
            nhomhangDTO.Manhomhang = txt_manhomhang.Text;
            nhomhangDTO.Tennhomhang = txt_tennhomhang.Text;
            nhomhangDTO.Ghichu = txt_ghichu.Text;
            nhomhangBLL.deleteCate(nhomhangDTO);
            MessageBox.Show("Thành công!");
            showData();
        }

        private void showOnTextBox(int d)
        {
            txt_manhomhang.Text = dataGridView1.Rows[d].Cells[0].Value.ToString();
            txt_tennhomhang.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
            txt_ghichu.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            if (current > 0) { current--; } else { current = maxRow - 1; }
            showOnTextBox(current);
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (current < maxRow - 1) { current++; }
            else { current = 0; }
            showOnTextBox(current);
        }
    }
}
