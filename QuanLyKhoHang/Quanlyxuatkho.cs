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
    public partial class Quanlyxuatkho : Form
    {
        tkxml fileXML = new tkxml();
        PhieuxuatkhoBLL phieuxuatkhoBLL = new PhieuxuatkhoBLL();
        HanghoaBLL hanghoaBLL = new HanghoaBLL();
        NhanvienBLL nhanvienBLL = new NhanvienBLL();
        public int current = 0;
        public int maxRow = 0;

        public Quanlyxuatkho()
        {
            InitializeComponent();
        }

        public void showData()
        {
            DataTable dt = new DataTable();
            dt = fileXML.HienThi("phieuxuatkho.xml");
            dataGridView1.DataSource = dt;
            maxRow = dataGridView1.RowCount - 1;
        }

        private void Quanlyxuatkho_Load(object sender, EventArgs e)
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
            dtp_nx.Value = DateTime.Today;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (phieuxuatkhoBLL.deliBillIDCheck(txtMaNhapKho.Text) == true)
            {
                MessageBox.Show("Mã phiếu nhập đã tồn tại.");
            }
            else
            {
                DateTime dt = DateTime.Parse(dtp_nx.Text);
                string dts = XmlConvert.ToString(dt);
                PhieuxuatkhoDTO phieunhapkhoDTO = new PhieuxuatkhoDTO();
                phieunhapkhoDTO.Mahang = cboMaHang.Text;
                phieunhapkhoDTO.Manhanvien = cboNhanVienNhap.Text;
                phieunhapkhoDTO.Ngayxuat = dts;
                phieunhapkhoDTO.Soluongxuat = int.Parse(txtSoLuong.Text);
                phieunhapkhoDTO.Maphieuxuat = txtMaNhapKho.Text;

                phieuxuatkhoBLL.addDeliBill(phieunhapkhoDTO);
                showData();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse(dtp_nx.Text);
            string dts = XmlConvert.ToString(dt);
            PhieuxuatkhoDTO phieunhapkhoDTO = new PhieuxuatkhoDTO();
            phieunhapkhoDTO.Mahang = cboMaHang.Text;
            phieunhapkhoDTO.Manhanvien = cboNhanVienNhap.Text;
            phieunhapkhoDTO.Ngayxuat = dts;
            phieunhapkhoDTO.Soluongxuat = int.Parse(txtSoLuong.Text);
            phieunhapkhoDTO.Maphieuxuat = txtMaNhapKho.Text;

            phieuxuatkhoBLL.editDeliBill(phieunhapkhoDTO);
            MessageBox.Show("Thành công!");
            showData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse(dtp_nx.Text);
            string dts = XmlConvert.ToString(dt);
            PhieuxuatkhoDTO phieunhapkhoDTO = new PhieuxuatkhoDTO();
            phieunhapkhoDTO.Mahang = cboMaHang.Text;
            phieunhapkhoDTO.Manhanvien = cboNhanVienNhap.Text;
            phieunhapkhoDTO.Ngayxuat = dts;
            phieunhapkhoDTO.Soluongxuat = int.Parse(txtSoLuong.Text);
            phieunhapkhoDTO.Maphieuxuat = txtMaNhapKho.Text;

            phieuxuatkhoBLL.deleteDeliBill(phieunhapkhoDTO);
            MessageBox.Show("Thành công!");
            showData();
        }

        private void showOnTextBox(int d)
        {
            txtMaNhapKho.Text = dataGridView1.Rows[d].Cells[0].Value.ToString();
            cboMaHang.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
            cboNhanVienNhap.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
            dtp_nx.Text = dataGridView1.Rows[d].Cells[3].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[d].Cells[4].Value.ToString();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string filter = txt_search.Text;
            phieuxuatkhoBLL.findData(dataGridView1, filter);
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_search.Text = "";
            showData();
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
