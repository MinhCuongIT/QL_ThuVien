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
    public class LoaiSachBUS
    {
        LoaiSachDAO loaiSachDAO = new LoaiSachDAO();

        public DataTable GetAllData()
        {
            return loaiSachDAO.GetAllData();
        }

        public bool Insert(LoaiSachDTO loaiSach)
        {
            if (Invalid(loaiSach.TenLoaiSach))
            {
                return false;
            }
            if (loaiSachDAO.IsExist(loaiSach))
            {
                throw new Exception("Loại sách đã tồn tại!");
                return false;
            }
            return loaiSachDAO.Insert(loaiSach);
        }

        public bool Update(LoaiSachDTO loaiSach)
        {
            if (Invalid(loaiSach.TenLoaiSach))
            {
                return false;
            }
            return loaiSachDAO.Update(loaiSach);
        }

        public bool Delete(LoaiSachDTO loaiSach)
        {
            return loaiSachDAO.Delete(loaiSach);
        }

        public bool IsExist(LoaiSachDTO loaiSach)
        {
            return loaiSachDAO.IsExist(loaiSach);
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