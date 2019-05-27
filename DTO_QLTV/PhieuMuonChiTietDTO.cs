using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
    public class PhieuMuonChiTietDTO
    {
        int id;
        int idPhieuMuon;
        int idSach;
        int soLuongMuon;

        public PhieuMuonChiTietDTO()
        {
        }

        public PhieuMuonChiTietDTO(int id, int idPhieuMuon, int idSach, int soLuongMuon)
        {
            this.id = id;
            this.idPhieuMuon = idPhieuMuon;
            this.idSach = idSach;
            this.soLuongMuon = soLuongMuon;
        }

        public int Id { get => id; set => id = value; }
        public int IdPhieuMuon { get => idPhieuMuon; set => idPhieuMuon = value; }
        public int IdSach { get => idSach; set => idSach = value; }
        public int SoLuongMuon { get => soLuongMuon; set => soLuongMuon = value; }
    }
}
