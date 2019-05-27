using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
    public class LoaiSachDTO
    {
        private int idLoaiSach;
        private string tenLoaiSach;

        public LoaiSachDTO()
        {
        }

        public LoaiSachDTO(int idLoaiSach, string tenLoaiSach)
        {
            this.idLoaiSach = idLoaiSach;
            this.tenLoaiSach = tenLoaiSach;
        }

        public int IdLoaiSach { get => idLoaiSach; set => idLoaiSach = value; }
        public string TenLoaiSach { get => tenLoaiSach; set => tenLoaiSach = value; }
    }
}
