using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace QuanLyKhoHang.BLL
{
    class StartupBLL
    {
        tkxml fileXML = new tkxml();

        public void createXML()
        {
            fileXML.TaoXML("hanghoa");
            fileXML.TaoXML("nhanvien");
            fileXML.TaoXML("nhomhang");
            fileXML.TaoXML("phieunhapkho");
            fileXML.TaoXML("phieuxuatkho");
            fileXML.TaoXML("taikhoan");
        }

        void updateOnEachTable(string tenBang)
        {
            string duongDan = tenBang + ".xml";
            DataTable table = fileXML.HienThi(duongDan);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string sql = "insert into " + tenBang + " values(";
                for (int j = 0; j < table.Columns.Count - 1; j++)
                {
                    sql += "N'" + table.Rows[i][j].ToString().Trim() + "',";
                }
                sql += "N'" + table.Rows[i][table.Columns.Count - 1].ToString().Trim() + "'";
                sql += ")";
                //MessageBox.Show(sql);
                fileXML.InsertOrUpDateSQL(sql);
            }
        }

        public void updateSQL()
        {
            try
            {
                fileXML.InsertOrUpDateSQL("delete from phieuxuatkho");
                fileXML.InsertOrUpDateSQL("delete from phieunhapkho");
                fileXML.InsertOrUpDateSQL("delete from hanghoa");
                fileXML.InsertOrUpDateSQL("delete from nhanvien");
                fileXML.InsertOrUpDateSQL("delete from nhomhang");
                fileXML.InsertOrUpDateSQL("delete from taikhoan");

                updateOnEachTable("nhanvien");
                updateOnEachTable("nhomhang");
                updateOnEachTable("hanghoa");
                updateOnEachTable("phieunhapkho");
                updateOnEachTable("phieuxuatkho");
                updateOnEachTable("taikhoan");
            }
            catch (Exception e)
            {
                MessageBox.Show("Thất bại!\n" + e);   
            }
        }
    }
}
