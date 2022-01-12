using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    class PhieuxuatkhoDTO
    {
        private string maphieuxuat;
        private string mahang;
        private string manhanvien;
        private string ngayxuat;
        private int soluongxuat;

        public string Maphieuxuat
        {
            get => maphieuxuat;
            set => maphieuxuat = value;
        }

        public string Mahang
        {
            get => mahang;
            set => mahang = value;
        }

        public string Manhanvien
        {
            get => manhanvien;
            set => manhanvien = value;
        }

        public string Ngayxuat
        {
            get => ngayxuat;
            set => ngayxuat = value;
        }

        public int Soluongxuat
        {
            get => soluongxuat;
            set => soluongxuat = value;
        }
    }
}
