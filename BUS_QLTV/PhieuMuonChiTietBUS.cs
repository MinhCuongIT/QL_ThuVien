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
    public class PhieuMuonChiTietBUS
    {
        PhieuMuonChiTietDAO phieuMuonChiTietDAO = new PhieuMuonChiTietDAO();

        public DataTable GetAllData()
        {
            return phieuMuonChiTietDAO.GetAllData();
        }

        public bool Insert(PhieuMuonChiTietDTO phieuMuonChiTiet)
        {
            if (Invalid(phieuMuonChiTiet.IdPhieuMuon.ToString()) ||
                Invalid(phieuMuonChiTiet.IdSach.ToString()) ||
                Invalid(phieuMuonChiTiet.SoLuongMuon.ToString()))
            {
                return false;
            }
            return phieuMuonChiTietDAO.Insert(phieuMuonChiTiet);
        }

        public bool Update(PhieuMuonChiTietDTO phieuMuonChiTiet)
        {
            if (Invalid(phieuMuonChiTiet.IdPhieuMuon.ToString()) ||
                Invalid(phieuMuonChiTiet.IdSach.ToString()) ||
                Invalid(phieuMuonChiTiet.SoLuongMuon.ToString()))
            {
                return false;
            }
            return phieuMuonChiTietDAO.Update(phieuMuonChiTiet);
        }

        public bool Delete(PhieuMuonChiTietDTO phieuMuonChiTiet)
        {
            return phieuMuonChiTietDAO.Delete(phieuMuonChiTiet);
        }

        public bool IsExist(PhieuMuonChiTietDTO phieuMuonChiTiet)
        {
            return phieuMuonChiTietDAO.IsExist(phieuMuonChiTiet);
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
