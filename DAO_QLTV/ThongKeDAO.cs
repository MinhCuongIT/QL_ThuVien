using DTO_QLTV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QLTV
{
    public class ThongKeDAO : DBConnection
    {
        public DataTable GetLoaiSachWithDetails()
        {
            string sql = "SELECT ls.TenLoaiSach, COUNT(s.IdSach) as Tong " +
                "FROM LoaiSach ls JOIN Sach s ON s.IdLoaiSach = ls.IdLoaiSach " +
                "GROUP BY ls.IdLoaiSach, ls.TenLoaiSach";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetLoaiSachWithDate(string date1, string date2)
        {
            string sql = $"SELECT ls.TenLoaiSach, SUM(ct.SoLuongMuon) as TONG " +
                $"FROM LoaiSach ls, Sach s, PhieuMuonChiTiet ct, PhieuMuon pm " +
                $"WHERE ls.IdLoaiSach = s.IdLoaiSach AND ct.IdPhieuMuon = pm.IdPhieuMuon AND ct.IdSach = s.IdSach AND pm.NgayMuon BETWEEN '{date1}' AND '{date2}' " +
                $"GROUP BY ls.IdLoaiSach, ls.TenLoaiSach";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public int GetDocGiaDungHan(string date1, string date2)
        {
            try
            {
                this.connection.Open();
                string sql = $"SELECT COUNT(*) as TONG " +
                    $"FROM PhieuMuon pm " +
                    $"WHERE pm.NgayTraThucTe BETWEEN pm.NgayMuon AND pm.NgayTraLyThuyet AND pm.NgayMuon BETWEEN '{date1}' AND '{date2}'";
                SqlCommand command = new SqlCommand(sql, connection);
                return (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                this.connection.Close();
            }
        }

        public int GetDocGiaTreHan(string date1, string date2)
        {
            try
            {
                this.connection.Open();
                string sql = $"SELECT COUNT(*) as TONG " +
                    $"FROM PhieuMuon pm " +
                    $"WHERE pm.NgayTraThucTe > pm.NgayTraLyThuyet AND pm.NgayMuon BETWEEN '{date1}' AND '{date2}'";
                SqlCommand command = new SqlCommand(sql, connection);
                return (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                this.connection.Close();
            }
        }

        public int GetTongSoSachTrongKho()
        {
            try
            {
                this.connection.Open();
                string sql = $"SELECT SUM(SoLuongTong) FROM SACH";
                SqlCommand command = new SqlCommand(sql, connection);
                return (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                this.connection.Close();
            }
        }

        public int GetTongSoSachConLai()
        {
            try
            {
                this.connection.Open();
                string sql = $"SELECT SUM(SoLuongConLai) FROM SACH";
                SqlCommand command = new SqlCommand(sql, connection);
                return (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                this.connection.Close();
            }
        }

        public int GetTongSoLuongDocGia(string date1, string date2)
        {
            try
            {
                this.connection.Open();
                string sql = $"SELECT COUNT(*) as Total " +
                    $"FROM ( SELECT DISTINCT IdDocGia FROM PhieuMuon " +
                    $"WHERE NgayMuon BETWEEN '{date1}' AND '{date2}') as tb";
                SqlCommand command = new SqlCommand(sql, connection);
                return (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                this.connection.Close();
            }
        }

        public DataTable GetTop10DocGia(string date1, string date2)
        {
            string sql = $"SELECT TOP(10) dg.TenDocGia, dg.DiaChi, pm.NgayMuon, SUM(ct.SoLuongMuon) as TongSoLuongMuon " +
                        $"FROM PhieuMuon pm, PhieuMuonChiTiet ct, DocGia dg " +
                        $"WHERE pm.IdPhieuMuon = ct.IdPhieuMuon AND dg.IdDocGia = pm.IdDocGia AND pm.NgayMuon BETWEEN '{date1}' AND '{date2}' " +
                        $"GROUP BY dg.IdDocGia, dg.TenDocGia, dg.DiaChi, pm.NgayMuon " +
                        $"ORDER BY SUM(ct.SoLuongMuon) DESC ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
