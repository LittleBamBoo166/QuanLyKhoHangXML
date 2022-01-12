using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    class NhanvienDTO
    {
        private string manhanvien;
        private string tennhanvien;

        public string Manhanvien
        {
            get => manhanvien;
            set => manhanvien = value;
        }

        public string Tennhanvien
        {
            get => tennhanvien;
            set => tennhanvien = value;
        }
    }
}
