using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using QuanLyKhoHang.DTO;
using System.Windows.Forms;
using System.Data;

namespace QuanLyKhoHang.BLL
{
    class PhieunhapkhoBLL
    {
        tkxml fileXML = new tkxml();

        public bool receiptIDCheck(string maphieunhap)
        {
            XmlTextReader reader = new XmlTextReader("phieunhapkho.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/_x0027_phieunhapkho_x0027_[maphieunhap='" + maphieunhap + "']");
            reader.Close();
            if (node != null)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public void addReceipt(PhieunhapkhoDTO pn)
        {
            string content = "<_x0027_phieunhapkho_x0027_>" +
                                "<maphieunhap>" + pn.Maphieunhap + "</maphieunhap>" +
                                "<mahang>" + pn.Mahang + "</mahang>" +
                                "<manhanvien>" + pn.Manhanvien + "</manhanvien>" +
                                "<ngaynhap>" + pn.Ngaynhap + "</ngaynhap>" +
                                "<soluongnhap>" + pn.Soluongnhap + "</soluongnhap>" +
                            "</_x0027_phieunhapkho_x0027_>";
            fileXML.Them("phieunhapkho.xml", content);
        }

        public void editReceipt(PhieunhapkhoDTO pn)
        {
            string content = "<maphieunhap>" + pn.Maphieunhap + "</maphieunhap>" +
                                "<mahang>" + pn.Mahang + "</mahang>" +
                                "<manhanvien>" + pn.Manhanvien + "</manhanvien>" +
                                "<ngaynhap>" + pn.Ngaynhap + "</ngaynhap>" +
                                "<soluongnhap>" + pn.Soluongnhap + "</soluongnhap>";
            fileXML.Sua("phieunhapkho.xml", "phieunhapkho", "maphieunhap", pn.Maphieunhap, content);
        }

        public void deleteReceipt(PhieunhapkhoDTO pn)
        {
            fileXML.Xoa("phieunhapkho.xml", "phieunhapkho", "maphieunhap", pn.Maphieunhap);
        }

        public void showData(DataGridView dvg)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("phieunhapkho.xml");
            XmlElement root = doc.DocumentElement;

            dvg.Rows.Clear();
            dvg.ColumnCount = 5;
            dvg.Columns[0].Name = "Mã phiếu nhập";
            dvg.Columns[1].Name = "Mã hàng";
            dvg.Columns[2].Name = "Mã nhân viên";
            dvg.Columns[3].Name = "Ngày nhập";
            dvg.Columns[4].Name = "Số lượng nhập";

            XmlNodeList xmlNodeList = root.SelectNodes("_x0027_phieunhapkho_x0027_");
            int index = 0;

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                dvg.Rows.Add();
                dvg.Rows[index].Cells[0].Value = xmlNode.SelectSingleNode("maphieunhap").InnerText;
                dvg.Rows[index].Cells[1].Value = xmlNode.SelectSingleNode("mahang").InnerText;
                dvg.Rows[index].Cells[2].Value = xmlNode.SelectSingleNode("manhanvien").InnerText;
                dvg.Rows[index].Cells[3].Value = xmlNode.SelectSingleNode("ngaynhap").InnerText;
                dvg.Rows[index].Cells[4].Value = xmlNode.SelectSingleNode("soluongnhap").InnerText;
                index++;
            }
        }

        public void findData(DataGridView dvg, string filter)
        {
            XmlTextReader reader = new XmlTextReader("phieunhapkho.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "maphieunhap";
            reader.Close();
            int index = dv.Find(filter);
            if (index == -1)
            {
                MessageBox.Show("Không tìm thấy");
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã phiếu nhập");
                dt.Columns.Add("Mã hàng");
                dt.Columns.Add("Mã nhân viên");
                dt.Columns.Add("Ngày nhập");
                dt.Columns.Add("Số lượng");

                object[] list = { dv[index]["maphieunhap"], dv[index]["mahang"], dv[index]["manhanvien"], dv[index]["ngaynhap"], dv[index]["soluongnhap"] };
                dt.Rows.Add(list);
                dvg.DataSource = dt;
            }
        }
    }
}
