using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
    public class PhieuMuonDTO
    {
        int idPhieuMuon;
        int idDocGia;
        DateTime ngayMuon;
        DateTime ngayTraLyThuyet;
        DateTime ngayTraThucTe;
        int tienCoc;


        public PhieuMuonDTO()
        {
        }

        public PhieuMuonDTO(int idPhieuMuon, int idDocGia, DateTime ngayMuon, DateTime ngayTraLyThuyet, DateTime ngayTraThucTe, int tienCoc)
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
        public DateTime NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public DateTime NgayTraLyThuyet { get => ngayTraLyThuyet; set => ngayTraLyThuyet = value; }
        public DateTime NgayTraThucTe { get => ngayTraThucTe; set => ngayTraThucTe = value; }
        public int TienCoc { get => tienCoc; set => tienCoc = value; }
    }
}
