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
    class NhomhangBLL
    {
        tkxml fileXML = new tkxml();

        public bool cateIDCheck(string manhomhang)
        {
            XmlTextReader reader = new XmlTextReader("nhomhang.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/_x0027_nhomhang_x0027_[manhomhang='" + manhomhang + "']");
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

        public void addCate(NhomhangDTO nh)
        {
            string content = "<_x0027_nhomhang_x0027_>" +
                                "<manhomhang>" + nh.Manhomhang + "</manhomhang>" +
                                "<tennhomhang>" + nh.Tennhomhang + "</tennhomhang>" +
                                "<ghichu>" + nh.Ghichu + "</ghichu>" +
                             "</_x0027_nhomhang_x0027_>";
            fileXML.Them("nhomhang.xml", content);
        }

        public void editCate(NhomhangDTO nh)
        {
            string content = "<manhomhang>" + nh.Manhomhang + "</manhomhang>" +
                                "<tennhomhang>" + nh.Tennhomhang + "</tennhomhang>" +
                                "<ghichu>" + nh.Ghichu + "</ghichu>";
            fileXML.Sua("nhomhang.xml", "nhomhang", "manhomhang", nh.Manhomhang, content);
        }

        public void deleteCate(NhomhangDTO nh)
        {
            fileXML.Xoa("nhomhang.xml", "nhomhang", "manhomhang", nh.Manhomhang);
        }

        public void showData(DataGridView dvg)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("nhomhang.xml");
            XmlElement root = doc.DocumentElement;

            dvg.Rows.Clear();
            dvg.ColumnCount = 3;
            dvg.Columns[0].Name = "Mã nhóm hàng";
            dvg.Columns[1].Name = "Tên nhóm hàng";
            dvg.Columns[2].Name = "Ghi chú";

            XmlNodeList xmlNodeList = root.SelectNodes("_x0027_nhomhang_x0027_");
            int index = 0;

            foreach(XmlNode xmlNode in xmlNodeList)
            {
                dvg.Rows.Add();
                dvg.Rows[index].Cells[0].Value = xmlNode.SelectSingleNode("manhomhang").InnerText;
                dvg.Rows[index].Cells[1].Value = xmlNode.SelectSingleNode("tennhomhang").InnerText;
                dvg.Rows[index].Cells[2].Value = xmlNode.SelectSingleNode("ghichu").InnerText;
                index++;
            }
        }

        public void showId(ComboBox cbb)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("nhomhang.xml");
            XmlElement root = doc.DocumentElement;

            XmlNodeList xmlNodeList = root.SelectNodes("_x0027_nhomhang_x0027_");
            int index = 0;

            cbb.Items.Clear();

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                cbb.Items.Add(xmlNode.SelectSingleNode("manhomhang").InnerText);
                index++;
            }
        }
    }
}
