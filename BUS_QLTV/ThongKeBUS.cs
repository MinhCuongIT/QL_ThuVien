using DAO_QLTV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLTV
{
    public class ThongKeBUS
    {
        ThongKeDAO thongKeDAO = new ThongKeDAO();
        public DataTable GetLoaiSachWithDetails()
        {
            return thongKeDAO.GetLoaiSachWithDetails();
        }
        public DataTable GetLoaiSachWithDate(string date1, string date2)
        {
            return thongKeDAO.GetLoaiSachWithDate(date1, date2);
        }
        public int GetDocGiaDungHan(string date1, string date2)
        {
            return thongKeDAO.GetDocGiaDungHan(date1, date2);
        }
        public int GetDocGiaTreHan(string date1, string date2)
        {
            return thongKeDAO.GetDocGiaTreHan(date1, date2);
        }
        public int GetTongSoSachTrongKho()
        {
            return thongKeDAO.GetTongSoSachTrongKho();
        }
        public int GetTongSoSachConLai()
        {
            return thongKeDAO.GetTongSoSachConLai();
        }
        public int GetTongSoLuongDocGia(string date1, string date2)
        {
            return thongKeDAO.GetTongSoLuongDocGia(date1, date2);
        }
        public DataTable GetTop10DocGia(string date1, string date2)
        {
            return thongKeDAO.GetTop10DocGia(date1, date2);

        }
    }
}
