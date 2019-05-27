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
    public class DocGiaBUS
    {
        DocGiaDAO docGiaDAO = new DocGiaDAO();

        public DataTable GetAllData()
        {
            return docGiaDAO.GetAllData();
        }

        public bool Insert(DocGiaDTO docGia)
        {
            if (Invalid(docGia.TenDocGia) || Invalid(docGia.Cmnd)|| Invalid(docGia.DiaChi))
            {
                return false;
            }
            if (docGiaDAO.IsExist(docGia))
            {
                throw new  Exception("Độc giả đã tồn tại!");
                return false;
            }
            return docGiaDAO.Insert(docGia);
        }

        public bool Update(DocGiaDTO docGia)
        {
            if (Invalid(docGia.TenDocGia) || Invalid(docGia.Cmnd) || Invalid(docGia.DiaChi))
            {
                return false;
            }
            return docGiaDAO.Update(docGia);
        }

        public bool Delete(DocGiaDTO docGia)
        {
            return docGiaDAO.Delete(docGia);
        }

        public bool IsExist(DocGiaDTO docGia)
        {
            return docGiaDAO.IsExist(docGia);
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