using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
    public class PhieuMuonDTO
    {
        private int idPhieuMuon;
        private int idDocGia;
        private string ngayMuon;
        private string ngayTraLyThuyet;
        private string ngayTraThucTe;
        private int tienCoc;


        public PhieuMuonDTO()
        {
        }

        public PhieuMuonDTO(int idPhieuMuon, int idDocGia, string ngayMuon, string ngayTraLyThuyet, string ngayTraThucTe, int tienCoc)
        {
            this.idPhieuMuon = idPhieuMuon;
            this.idDocGia = idDocGia;
            this.ngayMuon = ngayMuon;
            this.ngayTraLyThuyet = ngayTraLyThuyet;
            this.ngayTraThucTe = ngayTraThucTe;
            this.tienCoc = tienCoc;
        }

        public int IdPhieuMuon { get => idPhieuMuon; set => idPhieuMuon = value; }
        public int IdDocGia { get => idDocGia; set => idDocGia = value; }
        public string NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public string NgayTraLyThuyet { get => ngayTraLyThuyet; set => ngayTraLyThuyet = value; }
        public string NgayTraThucTe { get => ngayTraThucTe; set => ngayTraThucTe = value; }
        public int TienCoc { get => tienCoc; set => tienCoc = value; }
    }
}
