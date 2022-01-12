using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using QuanLyKhoHang.DTO;
using System.Windows.Forms;

namespace QuanLyKhoHang.BLL
{
    class NhanvienBLL
    {
        tkxml fileXML = new tkxml();

        public bool employeeIDCheck(string manhanvien)
        {
            XmlTextReader reader = new XmlTextReader("nhanvien.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/_x0027_nhanvien_x0027_[manhanvien='" + manhanvien + "']");
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

        public void addEmployee(NhanvienDTO nv)
        {
            string content = "<_x0027_nhanvien_x0027_>" +
                                "<manhanvien>" + nv.Manhanvien + "</manhanvien>" +
                                "<tennhanvien>" + nv.Tennhanvien + "</tennhanvien>" +
                            "</_x0027_nhanvien_x0027_>";
            fileXML.Them("nhanvien.xml", content);
        }

        public void editEmployee(NhanvienDTO nv)
        {
            string content = "<manhanvien>" + nv.Manhanvien + "</manhanvien>" +
                                "<tennhanvien>" + nv.Tennhanvien + "</tennhanvien>";
            fileXML.Sua("nhanvien.xml", "nhanvien", "manhanvien", nv.Manhanvien, content);
        }

        public void deleteEmployee(NhanvienDTO nv)
        {
            fileXML.Xoa("nhanvien.xml", "nhanvien", "manhanvien", nv.Manhanvien);
        }

        public void showData(DataGridView dvg)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("nhanvien.xml");
            XmlElement root = doc.DocumentElement;

            dvg.Rows.Clear();
            dvg.ColumnCount = 2;
            dvg.Columns[0].Name = "Mã nhân viên";
            dvg.Columns[1].Name = "Tên nhân viên";

            XmlNodeList xmlNodeList = root.SelectNodes("_x0027_nhanvien_x0027_");
            int index = 0;

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                dvg.Rows.Add();
                dvg.Rows[index].Cells[0].Value = xmlNode.SelectSingleNode("manhanvien").InnerText;
                dvg.Rows[index].Cells[1].Value = xmlNode.SelectSingleNode("tennhanvien").InnerText;
                index++;
            }
        }

        public void showId(ComboBox cbb)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("nhanvien.xml");
            XmlElement root = doc.DocumentElement;

            XmlNodeList xmlNodeList = root.SelectNodes("_x0027_nhanvien_x0027_");
            int index = 0;

            cbb.Items.Clear();

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                cbb.Items.Add(xmlNode.SelectSingleNode("manhanvien").InnerText);
                index++;
            }
        }
    }
}
