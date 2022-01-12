using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    class HanghoaDTO
    {
        private string mahang;
        private string tenhang;
        private string donvitinh;
        private long dongia;
        private long soluong;
        private string manhomhang;

        public string Mahang
        {
            get => mahang;
            set => mahang = value;
        }

        public string Tenhang
        {
            get => tenhang;
            set => tenhang = value;
        }

        public string Donvitinh
        {
            get => donvitinh;
            set => donvitinh = value;
        }

        public long Dongia
        {
            get => dongia;
            set => dongia = value;
        }

        public long Soluong
        {
            get => soluong;
            set => soluong = value;
        }

        public string Manhomhang
        {
            get => manhomhang;
            set => manhomhang = value;
        }
    }
}
