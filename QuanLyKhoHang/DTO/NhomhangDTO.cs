using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    class NhomhangDTO
    {
        private string manhomhang;
        private string tennhomhang;
        private string ghichu;

        public string Manhomhang
        {
            get => manhomhang;
            set => manhomhang = value;
        }

        public string Tennhomhang
        {
            get => tennhomhang;
            set => tennhomhang = value;
        }

        public string Ghichu
        {
            get => ghichu;
            set => ghichu = value;
        }
    }
}
