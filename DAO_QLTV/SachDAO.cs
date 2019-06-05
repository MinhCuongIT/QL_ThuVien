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
    public class SachDAO : DBConnection
    {
        public DataTable GetAllData()
        {
            string sql = "SELECT ls.IdLoaiSach, ls.TenLoaiSach, s.TenSach, s.NgonNgu, s.NhaXuatBan, s.NgayNhap, s.GiaTien, s.SoLuongTong, s.SoLuongConLai, s.IdSach " +
                "FROM Sach s LEFT JOIN LoaiSach ls ON s.IdLoaiSach = ls.IdLoaiSach";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetABook(int id)
        {
            string sql = $"SELECT ls.TenLoaiSach, s.TenSach, s.NgonNgu, s.NhaXuatBan, s.GiaTien " +
                $"FROM Sach s LEFT JOIN LoaiSach ls ON s.IdLoaiSach = ls.IdLoaiSach " +
                $"WHERE s.IdSach = {id}";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetSachByLoaiSach(int idLoaiSach)
        {
            string sql = $"SELECT ls.IdLoaiSach, ls.TenLoaiSach, s.IdSach, s.TenSach, s.NgonNgu, s.NhaXuatBan, s.NgayNhap, s.GiaTien " +
                $"FROM Sach s, LoaiSach ls " +
                $"WHERE ls.IdLoaiSach = s.IdLoaiSach AND ls.IdLoaiSach = {idLoaiSach}";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public bool Insert(SachDTO sach)
        {
            try
            {
                connection.Open();
                string sql = "INSERT INTO Sach(IdLoaiSach, NgonNgu, NhaXuatBan, TenSach, NgayNhap, GiaTien, SoLuongTong, SoLuongConLai) " +
                    "VALUES(@idLoaisach, @ngonNgu, @nhaXuatBan, @tenSach, @ngayNhap, @giaTien, @soLuongTong, @soLuongConLai)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idLoaisach", sach.IdLoaiSach);
                command.Parameters.AddWithValue("@ngonNgu", sach.NgonNgu);
                command.Parameters.AddWithValue("@nhaXuatBan", sach.NhaXuatBan);
                command.Parameters.AddWithValue("@tenSach", sach.TenSach);
                command.Parameters.AddWithValue("@ngayNhap", sach.NgayNhap);
                command.Parameters.AddWithValue("@giaTien", sach.GiaTien);
                command.Parameters.AddWithValue("@soLuongTong", sach.SoLuongTong);
                command.Parameters.AddWithValue("@soLuongConLai", sach.SoLuongConLai);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public bool Update(SachDTO sach)
        {
            try
            {
                connection.Open();
                string sql = "UPDATE Sach SET NgonNgu = @ngonNgu, NhaXuatBan = @nhaXuatBan, TenSach = @tenSach, NgayNhap = @ngayNhap, GiaTien = @giaTien, SoLuongTong = @soLuongTong, SoLuongConLai = @soLuongConLai WHERE IdSach = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ngonNgu", sach.NgonNgu);
                command.Parameters.AddWithValue("@nhaXuatBan", sach.NhaXuatBan);
                command.Parameters.AddWithValue("@tenSach", sach.TenSach);
                command.Parameters.AddWithValue("@ngayNhap", sach.NgayNhap);
                command.Parameters.AddWithValue("@giaTien", sach.GiaTien);
                command.Parameters.AddWithValue("@soLuongTong", sach.SoLuongTong);
                command.Parameters.AddWithValue("@soLuongConLai", sach.SoLuongConLai);
                command.Parameters.AddWithValue("@id", sach.Id);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public bool Delete(SachDTO sach)
        {
            try
            {
                connection.Open();
                string sql = "DELETE FROM Sach WHERE IdSach = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", sach.Id);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public bool IsExist(SachDTO sach)
        {
            try
            {
                connection.Open();
                string sql = "SELECT * FROM Sach WHERE IdSach = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", sach.Id);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public DataTable FillByTenSach(string str)
        {
            string sql = $"SELECT ls.IdLoaiSach, ls.TenLoaiSach, s.IdSach, s.TenSach, s.NgonNgu, s.NhaXuatBan, s.NgayNhap, s.GiaTien " +
                $"FROM Sach s, LoaiSach ls " +
                $"WHERE ls.IdLoaiSach = s.IdLoaiSach AND s.TenSach LIKE N'%{str}%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillByNgonNgu(string str)
        {
            string sql = $"SELECT ls.IdLoaiSach, ls.TenLoaiSach, s.IdSach, s.TenSach, s.NgonNgu, s.NhaXuatBan, s.NgayNhap, s.GiaTien " +
                $"FROM Sach s, LoaiSach ls " +
                $"WHERE ls.IdLoaiSach = s.IdLoaiSach AND s.NgonNgu LIKE N'%{str}%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillByNhaXuatBan(string str)
        {
            string sql = $"SELECT ls.IdLoaiSach, ls.TenLoaiSach, s.IdSach, s.TenSach, s.NgonNgu, s.NhaXuatBan, s.NgayNhap, s.GiaTien " +
                $"FROM Sach s, LoaiSach ls " +
                $"WHERE ls.IdLoaiSach = s.IdLoaiSach AND s.NhaXuatBan LIKE N'%{str}%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable FillByIdLoaiSach(int id)
        {
            string sql = $"SELECT ls.IdLoaiSach, ls.TenLoaiSach, s.IdSach, s.TenSach, s.NgonNgu, s.NhaXuatBan, s.NgayNhap, s.GiaTien " +
                $"FROM Sach s, LoaiSach ls " +
                $"WHERE ls.IdLoaiSach = s.IdLoaiSach AND ls.IdLoaiSach = {id}";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
