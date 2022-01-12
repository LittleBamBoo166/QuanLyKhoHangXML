using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Nhanvien : Form
    {
        tkxml fileXML = new tkxml();
        NhanvienBLL nhanvienBLL = new NhanvienBLL();
        public int current = 0;
        public int maxRow = 0;

        public void showData()
        {
            DataTable dt = new DataTable();
            dt = fileXML.HienThi("nhanvien.xml");
            dataGridView1.DataSource = dt;
            maxRow = dataGridView1.RowCount - 1;
        }

        public Nhanvien()
        {
            InitializeComponent();
        }

        private void Nhanvien_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            txt_mnv.Text = "";
            txt_tnv.Text = "";
            txt_mnv.Focus();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (nhanvienBLL.employeeIDCheck(txt_mnv.Text) == true)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại.");
            }
            else
            {
                NhanvienDTO nhanvienDTO = new NhanvienDTO();
                nhanvienDTO.Manhanvien = txt_mnv.Text;
                nhanvienDTO.Tennhanvien = txt_tnv.Text;
                nhanvienBLL.addEmployee(nhanvienDTO);
                showData();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            NhanvienDTO nhanvienDTO = new NhanvienDTO();
            nhanvienDTO.Manhanvien = txt_mnv.Text;
            nhanvienDTO.Tennhanvien = txt_tnv.Text;
            nhanvienBLL.editEmployee(nhanvienDTO);
            MessageBox.Show("Thành công!");
            showData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            NhanvienDTO nhanvienDTO = new NhanvienDTO();
            nhanvienDTO.Manhanvien = txt_mnv.Text;
            nhanvienDTO.Tennhanvien = txt_tnv.Text;
            nhanvienBLL.deleteEmployee(nhanvienDTO);
            MessageBox.Show("Thành công!");
            showData();
        }

        private void showOnTextBox(int d)
        {
            txt_mnv.Text = dataGridView1.Rows[d].Cells[0].Value.ToString();
            txt_tnv.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
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
