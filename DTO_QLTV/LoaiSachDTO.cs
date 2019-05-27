using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
    public class LoaiSachDTO
    {
        private int loaiSach;
        private string tenLoaiSach;

        public LoaiSachDTO()
        {
        }

        public LoaiSachDTO(int loaiSach, string tenLoaiSach)
        {
            this.loaiSach = loaiSach;
            this.tenLoaiSach = tenLoaiSach;
        }

        public int LoaiSach { get => loaiSach; set => loaiSach = value; }
        public string TenLoaiSach { get => tenLoaiSach; set => tenLoaiSach = value; }
    }
}
