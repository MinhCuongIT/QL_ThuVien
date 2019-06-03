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
    public class SachBUS
    {
        SachDAO sachDAO = new SachDAO();

        public DataTable GetAllData()
        {
            return sachDAO.GetAllData();
        }
        public DataTable GetABook(int id)
        {
            return sachDAO.GetABook(id);
        }
        public DataTable GetSachByLoaiSach(int idLoaiSach)
        {
            return sachDAO.GetSachByLoaiSach(idLoaiSach);
        }

        public bool Insert(SachDTO sach)
        {
            if (Invalid(sach.IdLoaiSach.ToString()) ||
                Invalid(sach.NgonNgu.ToString()) ||
                Invalid(sach.NhaXuatBan.ToString()) ||
                Invalid(sach.TenSach.ToString()) ||
                Invalid(sach.NgayNhap.ToString()) ||
                Invalid(sach.GiaTien.ToString()) ||
                Invalid(sach.SoLuongConLai.ToString()) ||
                Invalid(sach.SoLuongTong.ToString()))
            {
                return false;
            }
            return sachDAO.Insert(sach);
        }

        public bool Update(SachDTO sach)
        {
            if (Invalid(sach.IdLoaiSach.ToString()) ||
                Invalid(sach.NgonNgu.ToString()) ||
                Invalid(sach.NhaXuatBan.ToString()) ||
                Invalid(sach.TenSach.ToString()) ||
                Invalid(sach.NgayNhap.ToString()) ||
                Invalid(sach.GiaTien.ToString()) ||
                Invalid(sach.SoLuongConLai.ToString()) ||
                Invalid(sach.SoLuongTong.ToString()))
            {
                return false;
            }
            return sachDAO.Update(sach);
        }

        public bool Delete(SachDTO sach)
        {
            return sachDAO.Delete(sach);
        }

        public bool IsExist(SachDTO sach)
        {
            return sachDAO.IsExist(sach);
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
