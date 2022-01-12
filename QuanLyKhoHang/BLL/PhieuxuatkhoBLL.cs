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
    class PhieuxuatkhoBLL
    {
        tkxml fileXML = new tkxml();

        public bool deliBillIDCheck(string maphieuxuat)
        {
            XmlTextReader reader = new XmlTextReader("phieuxuatkho.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/phieuxuatkho[_x0027_maphieuxuat_x0027_='" + maphieuxuat + "']");
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

        public void addDeliBill(PhieuxuatkhoDTO px)
        {
            string content = "<_x0027_phieuxuatkho_x0027_>" +
                                "<maphieuxuat>" + px.Maphieuxuat + "</maphieuxuat>" +
                                "<mahang>" + px.Mahang + "</mahang>" +
                                "<manhanvien>" + px.Manhanvien + "</manhanvien>" +
                                "<ngayxuat>" + px.Ngayxuat + "</ngayxuat>" +
                                "<soluongxuat>" + px.Soluongxuat + "</soluongxuat>" +
                            "</_x0027_phieuxuatkho_x0027_>";
            fileXML.Them("phieuxuatkho.xml", content);
        }

        public void editDeliBill(PhieuxuatkhoDTO px)
        {
            string content = "<maphieuxuat>" + px.Maphieuxuat + "</maphieuxuat>" +
                                "<mahang>" + px.Mahang + "</mahang>" +
                                "<manhanvien>" + px.Manhanvien + "</manhanvien>" +
                                "<ngayxuat>" + px.Ngayxuat + "</ngayxuat>" +
                                "<soluongxuat>" + px.Soluongxuat + "</soluongxuat>";
            fileXML.Sua("phieuxuatkho.xml", "phieuxuatkho", "maphieuxuat", px.Maphieuxuat, content);
        }

        public void deleteDeliBill(PhieuxuatkhoDTO px)
        {
            fileXML.Xoa("phieuxuatkho.xml", "phieuxuatkho", "maphieuxuat", px.Maphieuxuat);
        }

        public void showData(DataGridView dvg)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("phieuxuatkho.xml");
            XmlElement root = doc.DocumentElement;

            dvg.Rows.Clear();
            dvg.ColumnCount = 5;
            dvg.Columns[0].Name = "Mã phiếu xuất";
            dvg.Columns[1].Name = "Mã hàng";
            dvg.Columns[2].Name = "Mã nhân viên";
            dvg.Columns[3].Name = "Ngày xuất";
            dvg.Columns[4].Name = "Số lượng xuất";

            XmlNodeList xmlNodeList = root.SelectNodes("_x0027_phieuxuatkho_x0027_");
            int index = 0;

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                dvg.Rows.Add();
                dvg.Rows[index].Cells[0].Value = xmlNode.SelectSingleNode("maphieuxuat").InnerText;
                dvg.Rows[index].Cells[1].Value = xmlNode.SelectSingleNode("mahang").InnerText;
                dvg.Rows[index].Cells[2].Value = xmlNode.SelectSingleNode("manhanvien").InnerText;
                dvg.Rows[index].Cells[3].Value = xmlNode.SelectSingleNode("ngayxuat").InnerText;
                dvg.Rows[index].Cells[4].Value = xmlNode.SelectSingleNode("soluongxuat").InnerText;
                index++;
            }
        }

        public void findData(DataGridView dvg, string filter)
        {
            XmlTextReader reader = new XmlTextReader("phieuxuatkho.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "maphieuxuat";
            reader.Close();
            int index = dv.Find(filter);
            if (index == -1)
            {
                MessageBox.Show("Không tìm thấy");
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã phiếu xuất");
                dt.Columns.Add("Mã hàng");
                dt.Columns.Add("Mã nhân viên");
                dt.Columns.Add("Ngày xuất");
                dt.Columns.Add("Số lượng");

                object[] list = { dv[index]["maphieuxuat"], dv[index]["mahang"], dv[index]["manhanvien"], dv[index]["ngayxuat"], dv[index]["soluongxuat"] };
                dt.Rows.Add(list);
                dvg.DataSource = dt;
            }
        }
    }
}
