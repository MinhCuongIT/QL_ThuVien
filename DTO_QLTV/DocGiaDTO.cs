using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
    public class DocGiaDTO
    {
        int id;
        string tenDocGia;
        string cmnd;
        string diaChi;

        public DocGiaDTO()
        {
        }

        public DocGiaDTO(int id, string tenDocGia, string cmnd, string diaChi)
        {
            this.id = id;
            this.tenDocGia = tenDocGia;
            this.cmnd = cmnd;
            this.diaChi = diaChi;
        }

        public int Id { get => id; set => id = value; }
        public string TenDocGia { get => tenDocGia; set => tenDocGia = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}
