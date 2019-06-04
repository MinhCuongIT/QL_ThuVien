using DAO_QLTV;
using DTO_QLTV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLTV
{
    public class PhieuMuonBUS
    {
        PhieuMuonDAO phieuMuonDAO = new PhieuMuonDAO();

        public DataTable GetAllData()
        {

            return phieuMuonDAO.GetAllData();
        }

        public DataTable GetDataByIdDocGia(int id)
        {
            return phieuMuonDAO.GetDataByIdDocGia(id);
        }

        public DataTable SearchByCmnd(string cmnd)
        {
            return phieuMuonDAO.SearchByCmnd(cmnd);
        }

        public DataTable SearchByName(string name)
        {
            return phieuMuonDAO.SearchByName(name);
        }

        public int Insert(PhieuMuonDTO phieuMuon)
        {
            if (Invalid(
                phieuMuon.IdDocGia.ToString()) ||
                phieuMuon.NgayMuon == null ||
                phieuMuon.NgayMuon == null ||
                phieuMuon.NgayTraLyThuyet == null ||
                phieuMuon.TienCoc == null)
            {
                return -1;
            }

            return phieuMuonDAO.Insert(phieuMuon);
        }

        public bool Update(PhieuMuonDTO phieuMuon)
        {
            if (Invalid(
                phieuMuon.IdDocGia.ToString()) ||
                phieuMuon.NgayMuon == null ||
                phieuMuon.NgayMuon == null ||
                phieuMuon.NgayTraLyThuyet == null ||
                phieuMuon.NgayTraThucTe == null ||
                phieuMuon.TienCoc == null)
            {
                return false;
            }

            return phieuMuonDAO.Update(phieuMuon);
        }

        public bool UpdateDayRelease(int id, DateTime d)
        {
            return phieuMuonDAO.UpdateDayRelease(id, d);
        }

        public bool Delete(PhieuMuonDTO phieuMuon)
        {
            return phieuMuonDAO.Delete(phieuMuon);
        }

        public bool IsExist(PhieuMuonDTO phieuMuon)
        {
            return phieuMuonDAO.IsExist(phieuMuon);
        }

        public bool IsExistDocGia(int idDocGia)
        {
            return phieuMuonDAO.IsExistDocGia(idDocGia);
        }

        public bool IsValid(int idDocGia)
        {
            return phieuMuonDAO.IsValid(idDocGia);
        }

        public bool IsTraSachRoi(int idDocGia)
        {
            return phieuMuonDAO.IsTraSachRoi(idDocGia);
        }

        #region Methods
        /// <summary>
        /// Kiểm tra một chuỗi hợp lệ
        /// </summary>
        /// <param name="str">Chuỗi bất kì</param>
        /// <returns>true nếu hợp lệ, ngược lại</returns>
        private bool Invalid(string str)
        {
            return string.IsNullOrEmpty(str);
        }
        #endregion
    }
}
