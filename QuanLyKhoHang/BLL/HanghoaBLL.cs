using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using QuanLyKhoHang.DTO;
using System.Windows.Forms;
using System.Data;

namespace QuanLyKhoHang.BLL
{
    class HanghoaBLL
    {
        tkxml fileXML = new tkxml();

        public bool proIDCheck(string mahang)
        {
            XmlTextReader reader = new XmlTextReader("hanghoa.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/_x0027_hanghoa_x0027_[mahang='" + mahang + "']");
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

        public void addPro(HanghoaDTO hh)
        {
            string content = "<_x0027_hanghoa_x0027_>" +
                                "<mahang>" + hh.Mahang + "</mahang>" +
                                "<tenhang>" + hh.Tenhang + "</tenhang>" +
                                "<donvitinh>" + hh.Donvitinh + "</donvitinh>" +
                                "<dongia>" + hh.Dongia + "</dongia>" +
                                "<soluong>" + hh.Soluong + "</soluong>" +
                                "<manhomhang>" + hh.Manhomhang + "</manhomhang>" +
                            "</_x0027_hanghoa_x0027_>";
            fileXML.Them("hanghoa.xml", content);
        }

        public void editPro(HanghoaDTO hh)
        {
            string content = "<mahang>" + hh.Mahang + "</mahang>" +
                                "<tenhang>" + hh.Tenhang + "</tenhang>" +
                                "<donvitinh>" + hh.Donvitinh + "</donvitinh>" +
                                "<dongia>" + hh.Dongia + "</dongia>" +
                                "<soluong>" + hh.Soluong + "</soluong>" +
                                "<manhomhang>" + hh.Manhomhang + "</manhomhang>";
            fileXML.Sua("hanghoa.xml", "hanghoa", "mahang", hh.Mahang, content);
        }

        public void deletePro(HanghoaDTO hh)
        {
            fileXML.Xoa("hanghoa.xml", "hanghoa", "mahang", hh.Mahang);
        }

        public void sortData(DataGridView dvg, string filter)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("hanghoa.xml");
            XmlElement root = doc.DocumentElement;

            dvg.Rows.Clear();
            dvg.ColumnCount = 5;
            dvg.Columns[0].Name = "Mã hàng hoá";
            dvg.Columns[1].Name = "Tên hàng hoá";
            dvg.Columns[2].Name = "Đơn vị tính";
            dvg.Columns[3].Name = "Đơn giá";
            dvg.Columns[4].Name = "Mã nhóm hàng";            

            XmlNodeList xmlNodeList = root.SelectNodes("_x0027_hanghoa_x0027_");
            int index = 0;

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                string tmp = xmlNode.SelectSingleNode("manhomhang").InnerText;
                if (filter == tmp || filter == "Tất cả")
                {
                    dvg.Rows.Add();
                    dvg.Rows[index].Cells[0].Value = xmlNode.SelectSingleNode("mahang").InnerText;
                    dvg.Rows[index].Cells[1].Value = xmlNode.SelectSingleNode("tenhang").InnerText;
                    dvg.Rows[index].Cells[2].Value = xmlNode.SelectSingleNode("donvitinh").InnerText;
                    dvg.Rows[index].Cells[3].Value = xmlNode.SelectSingleNode("dongia").InnerText;
                    dvg.Rows[index].Cells[4].Value = xmlNode.SelectSingleNode("manhomhang").InnerText;
                    index++;
                }                
            }
        }

        public void findData(DataGridView dvg, string filter)
        {
            XmlTextReader reader = new XmlTextReader("hanghoa.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "mahang";
            reader.Close();
            int index = dv.Find(filter);
            if (index == -1)
            {
                MessageBox.Show("Không tìm thấy");
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã hàng hoá");
                dt.Columns.Add("Tên hàng hoá");
                dt.Columns.Add("Đơn vị tính");
                dt.Columns.Add("Đơn giá");
                dt.Columns.Add("Số lượng");
                dt.Columns.Add("Mã nhóm hàng");


                object[] list = { dv[index]["mahang"], dv[index]["tenhang"], dv[index]["donvitinh"], dv[index]["dongia"], dv[index]["soluong"], dv[index]["manhomhang"] };
                dt.Rows.Add(list);
                dvg.DataSource = dt;
            }
        }

        public void showId(ComboBox cbb)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("hanghoa.xml");
            XmlElement root = doc.DocumentElement;

            XmlNodeList xmlNodeList = root.SelectNodes("_x0027_hanghoa_x0027_");
            int index = 0;

            cbb.Items.Clear();

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                cbb.Items.Add(xmlNode.SelectSingleNode("mahang").InnerText);
                index++;
            }
        }
    }
}
