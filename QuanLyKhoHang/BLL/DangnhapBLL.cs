using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyKhoHang.BLL
{
    class DangnhapBLL
    {
        tkxml fileXML = new tkxml();

        public bool loginCheck(string madangnhap, string matkhau)
        {
            XmlTextReader reader = new XmlTextReader("taikhoan.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/_x0027_taikhoan_x0027_[mataikhoan='" + madangnhap + "']");
            node = doc.SelectSingleNode("NewDataSet/_x0027_taikhoan_x0027_[matkhau='" + matkhau + "']");
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

        public void addAccount(string madangnhap, string matkhau)
        {
            string content = "<_x0027_taikhoan_x0027_>" +
                                "<mataikhoan>" + madangnhap + "</mataikhoan>" +
                                "<matkhau>" + matkhau + "</matkhau>" +
                             "</_x0027_taikhoan_x0027_>";
            fileXML.Them("taikhoan.xml", content);
        }

        public void deleteAccount(string madangnhap)
        {
            fileXML.Xoa("taikhoan.xml", "taikhoan", "mataikhoan", madangnhap);
        }

        public bool accountExistenceCheck(string madangnhap)
        {
            XmlTextReader reader = new XmlTextReader("taikhoan.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/_x0027_taikhoan_x0027_[mataikhoan='" + madangnhap + "']");
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

        public void changePassword(string madangnhap, string matkhau)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "\\taikhoan.xml");
            XmlNode node1 = doc1.SelectSingleNode("NewDataSet/_x0027_taikhoan_x0027_[mataikhoan = '" + madangnhap + "']");
            if (node1 != null)
            {
                node1.ChildNodes[1].InnerText = matkhau;
                doc1.Save(Application.StartupPath + "\\taikhoan.xml");
            }
        }

        public bool loginExistenceCheck(string path, string madangnhap, string matkhau)
        {
            DataTable dt = new DataTable();
            dt = fileXML.HienThi(path);
            dt.DefaultView.RowFilter = "mataikhoan = '" + madangnhap + "' AND matkhau = '" + matkhau + "'";
            if (dt.DefaultView.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
