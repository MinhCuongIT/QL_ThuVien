using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
    public class SachDTO
    {
        private int id;
        private int idLoaiSach;
        private string ngonNgu;
        private string nhaXuatBan;
        private string tenSach;
        private string ngayNhap;
        private int giaTien;
        private int soLuongTong;
        private int soLuongConLai;

        public SachDTO()
        {
        }

        public SachDTO(int id, int idLoaiSach, string ngonNgu, string nhaXuatBan, string tenSach, string ngayNhap, int giaTien, int soLuongTong, int soLuongConLai)
        {
            this.id = id;
            this.idLoaiSach = idLoaiSach;
            this.ngonNgu = ngonNgu;
            this.nhaXuatBan = nhaXuatBan;
            this.tenSach = tenSach;
            this.ngayNhap = ngayNhap;
            this.giaTien = giaTien;
            this.soLuongTong = soLuongTong;
            this.soLuongConLai = soLuongConLai;
        }

        public int Id { get => id; set => id = value; }
        public int IdLoaiSach { get => idLoaiSach; set => idLoaiSach = value; }
        public string NgonNgu { get => ngonNgu; set => ngonNgu = value; }
        public string NhaXuatBan { get => nhaXuatBan; set => nhaXuatBan = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public int GiaTien { get => giaTien; set => giaTien = value; }
        public int SoLuongTong { get => soLuongTong; set => soLuongTong = value; }
        public int SoLuongConLai { get => soLuongConLai; set => soLuongConLai = value; }
    }
}
