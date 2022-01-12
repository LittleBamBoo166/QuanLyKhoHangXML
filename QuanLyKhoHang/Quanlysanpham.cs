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
    public partial class Quanlysanpham : Form
    {
        tkxml fileXML = new tkxml();
        HanghoaBLL hanghoaBLL = new HanghoaBLL();
        NhomhangBLL nhomhangBLL = new NhomhangBLL();
        public int current = 0;
        public int maxRow = 0;

        public Quanlysanpham()
        {
            InitializeComponent();
        }

        public void showData()
        {
            DataTable dt = new DataTable();
            dt = fileXML.HienThi("hanghoa.xml");
            dataGridView1.DataSource = dt;
            maxRow = dataGridView1.RowCount - 1;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            txt_dvt.Text = "";
            txt_gia.Text = "";
            txt_masp.Text = "";
            txt_search.Text = "";
            txt_tensp.Text = "";
            cbo_manhomhang.Text = "";
            txt_slg.Text = "";
            txt_masp.Focus();
        }

        private void Quanlysanpham_Load(object sender, EventArgs e)
        {
            nhomhangBLL.showId(cbo_manhomhang);
            showData();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (hanghoaBLL.proIDCheck(txt_masp.Text) == true)
            {
                MessageBox.Show("Mã hàng hoá đã tồn tại.");
            }
            else
            {
                HanghoaDTO hanghoaDTO = new HanghoaDTO();
                hanghoaDTO.Mahang = txt_masp.Text;
                hanghoaDTO.Tenhang = txt_tensp.Text;
                hanghoaDTO.Dongia = long.Parse(txt_gia.Text);
                hanghoaDTO.Donvitinh = txt_dvt.Text;
                hanghoaDTO.Soluong = long.Parse(txt_slg.Text);
                hanghoaDTO.Manhomhang = cbo_manhomhang.SelectedItem.ToString();

                hanghoaBLL.addPro(hanghoaDTO);
                showData();
            }                
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            HanghoaDTO hanghoaDTO = new HanghoaDTO();
            hanghoaDTO.Mahang = txt_masp.Text;
            hanghoaDTO.Tenhang = txt_tensp.Text;
            hanghoaDTO.Dongia = long.Parse(txt_gia.Text);
            hanghoaDTO.Donvitinh = txt_dvt.Text;
            hanghoaDTO.Soluong = long.Parse(txt_slg.Text);
            hanghoaDTO.Manhomhang = cbo_manhomhang.SelectedItem.ToString();

            hanghoaBLL.editPro(hanghoaDTO);
            MessageBox.Show("Thành công!");
            showData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            HanghoaDTO hanghoaDTO = new HanghoaDTO();
            hanghoaDTO.Mahang = txt_masp.Text;
            hanghoaDTO.Tenhang = txt_tensp.Text;
            hanghoaDTO.Dongia = long.Parse(txt_gia.Text);
            hanghoaDTO.Donvitinh = txt_dvt.Text;
            hanghoaDTO.Soluong = long.Parse(txt_slg.Text);
            hanghoaDTO.Manhomhang = cbo_manhomhang.SelectedItem.ToString();

            hanghoaBLL.deletePro(hanghoaDTO);
            MessageBox.Show("Thành công!");
            showData();
        }

        private void showOnTextBox(int d)
        {
            txt_masp.Text = dataGridView1.Rows[d].Cells[0].Value.ToString();
            txt_tensp.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
            txt_dvt.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
            txt_gia.Text = dataGridView1.Rows[d].Cells[3].Value.ToString();
            txt_slg.Text = dataGridView1.Rows[d].Cells[4].Value.ToString();
            cbo_manhomhang.Text = dataGridView1.Rows[d].Cells[5].Value.ToString();
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

        private void btn_search_Click(object sender, EventArgs e)
        {
            string filter = txt_search.Text;
            hanghoaBLL.findData(dataGridView1, filter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_search.Text = "";
            showData();
        }
    }
}
