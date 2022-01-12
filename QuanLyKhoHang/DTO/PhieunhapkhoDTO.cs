using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    class PhieunhapkhoDTO
    {
        private string maphieunhap;
        private string mahang;
        private string manhanvien;
        private string ngaynhap;
        private int soluongnhap;

        public string Maphieunhap
        {
            get => maphieunhap;
            set => maphieunhap = value;
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

        public string Ngaynhap
        {
            get => ngaynhap;
            set => ngaynhap = value;
        }

        public int Soluongnhap
        {
            get => soluongnhap;
            set => soluongnhap = value;
        }
    }
}
