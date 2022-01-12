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
using System.Xml;

namespace QuanLyKhoHang
{
    public partial class Quanlynhapkho : Form
    {
        tkxml fileXML = new tkxml();
        PhieunhapkhoBLL phieunhapkhoBLL = new PhieunhapkhoBLL();
        HanghoaBLL hanghoaBLL = new HanghoaBLL();
        NhanvienBLL nhanvienBLL = new NhanvienBLL();
        public int current = 0;
        public int maxRow = 0;

        public Quanlynhapkho()
        {
            InitializeComponent();
        }

        public void showData()
        {
            DataTable dt = new DataTable();
            dt = fileXML.HienThi("phieunhapkho.xml");
            dataGridView1.DataSource = dt;
            maxRow = dataGridView1.RowCount - 1;
        }

        private void Quanlynhapkho_Load(object sender, EventArgs e)
        {
            hanghoaBLL.showId(cboMaHang);
            nhanvienBLL.showId(cboNhanVienNhap);
            showData();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            txtMaNhapKho.Text = "";
            cboMaHang.Text = "";
            cboNhanVienNhap.Text = "";
            txtSoLuong.Text = "";
            dateTimePickerNgaynhapkho.Value = DateTime.Today;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (phieunhapkhoBLL.receiptIDCheck(txtMaNhapKho.Text) == true)
            {
                MessageBox.Show("Mã phiếu nhập đã tồn tại.");
            }
            else
            {
                DateTime dt = DateTime.Parse(dateTimePickerNgaynhapkho.Text);
                string dts = XmlConvert.ToString(dt);
                PhieunhapkhoDTO phieunhapkhoDTO = new PhieunhapkhoDTO();
                phieunhapkhoDTO.Mahang = cboMaHang.Text;
                phieunhapkhoDTO.Manhanvien = cboNhanVienNhap.Text;
                phieunhapkhoDTO.Ngaynhap = dts;
                phieunhapkhoDTO.Soluongnhap = int.Parse(txtSoLuong.Text);
                phieunhapkhoDTO.Maphieunhap = txtMaNhapKho.Text;

                phieunhapkhoBLL.addReceipt(phieunhapkhoDTO);
                showData();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse(dateTimePickerNgaynhapkho.Text);
            string dts = XmlConvert.ToString(dt);
            PhieunhapkhoDTO phieunhapkhoDTO = new PhieunhapkhoDTO();
            phieunhapkhoDTO.Mahang = cboMaHang.Text;
            phieunhapkhoDTO.Manhanvien = cboNhanVienNhap.Text;
            phieunhapkhoDTO.Ngaynhap = dts;
            phieunhapkhoDTO.Soluongnhap = int.Parse(txtSoLuong.Text);
            phieunhapkhoDTO.Maphieunhap = txtMaNhapKho.Text;

            phieunhapkhoBLL.editReceipt(phieunhapkhoDTO);
            MessageBox.Show("Thành công!");
            showData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse(dateTimePickerNgaynhapkho.Text);
            string dts = XmlConvert.ToString(dt);
            PhieunhapkhoDTO phieunhapkhoDTO = new PhieunhapkhoDTO();
            phieunhapkhoDTO.Mahang = cboMaHang.Text;
            phieunhapkhoDTO.Manhanvien = cboNhanVienNhap.Text;
            phieunhapkhoDTO.Ngaynhap = dts;
            phieunhapkhoDTO.Soluongnhap = int.Parse(txtSoLuong.Text);
            phieunhapkhoDTO.Maphieunhap = txtMaNhapKho.Text;

            phieunhapkhoBLL.deleteReceipt(phieunhapkhoDTO);
            MessageBox.Show("Thành công!");
            showData();
        }

        private void showOnTextBox(int d)
        {
            txtMaNhapKho.Text = dataGridView1.Rows[d].Cells[0].Value.ToString();
            cboMaHang.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
            cboNhanVienNhap.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
            dateTimePickerNgaynhapkho.Text = dataGridView1.Rows[d].Cells[3].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[d].Cells[4].Value.ToString();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string filter = txt_search.Text;
            phieunhapkhoBLL.findData(dataGridView1, filter);
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

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_search.Text = "";
            showData();
        }
    }
}
