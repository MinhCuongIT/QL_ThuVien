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
    public class TaiKhoanBUS
    {
        TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();

        public DataTable GetAllData()
        {
            return taiKhoanDAO.GetAllData();
        }
        public DataTable GetAccountByUsername(string username)
        {
            return taiKhoanDAO.GetAccountByUsername(username);
        }
        public bool Insert(TaiKhoanDTO taiKhoan)
        {
            if (Invalid(taiKhoan.Username) ||
                Invalid(taiKhoan.Password) ||
                Invalid(taiKhoan.TenHienThi) ||
                Invalid(taiKhoan.VaiTro.ToString()))
            {
                return false;
            }
            if (this.taiKhoanDAO.IsExist(taiKhoan))
            {
                throw new Exception("Tài khoản đã tồn tại!");
                return false;
            }
            return taiKhoanDAO.Insert(taiKhoan);
        }

        public bool Update(TaiKhoanDTO taiKhoan)
        {
            return taiKhoanDAO.Update(taiKhoan);
        }

        public bool Delete(TaiKhoanDTO taiKhoan)
        {
            return taiKhoanDAO.Delete(taiKhoan);
        }

        public bool IsExist(TaiKhoanDTO taiKhoan)
        {
            return taiKhoanDAO.IsExist(taiKhoan);
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
