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
    public class PhieuMuonDAO : DBConnection
    {
        public DataTable GetAllData()
        {
            string sql = "SELECT dg.TenDocGia, pm.NgayMuon, pm.NgayTraLyThuyet, pm.TienCoc, s.TenSach, ct.SoLuongMuon, dg.IdDocGia " +
                "FROM PhieuMuon pm, PhieuMuonChiTiet ct, DocGia dg, Sach s " +
                "WHERE pm.IdDocGia = dg.IdDocGia AND pm.IdPhieuMuon = ct.IdPhieuMuon AND ct.IdSach = s.IdSach";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetDataByIdDocGia(int id)
        {
            string sql = $"SELECT * " +
                $"FROM PhieuMuon " +
                $"WHERE IdDocGia = {id}";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable SearchByName(string name)
        {
            string sql = $"SELECT dg.TenDocGia, pm.NgayMuon, pm.NgayTraLyThuyet, pm.TienCoc, s.TenSach, ct.SoLuongMuon, dg.IdDocGia " +
                $"FROM PhieuMuon pm, PhieuMuonChiTiet ct, DocGia dg, Sach s " +
                $"WHERE pm.IdDocGia = dg.IdDocGia AND pm.IdPhieuMuon = ct.IdPhieuMuon AND ct.IdSach = s.IdSach AND dg.TenDocGia LIKE N'%{name}%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable SearchByCmnd(string cmnd)
        {
            string sql = $"SELECT dg.TenDocGia, pm.NgayMuon, pm.NgayTraLyThuyet, pm.TienCoc, s.TenSach, ct.SoLuongMuon, dg.IdDocGia " +
                $"FROM PhieuMuon pm, PhieuMuonChiTiet ct, DocGia dg, Sach s " +
                $"WHERE pm.IdDocGia = dg.IdDocGia AND pm.IdPhieuMuon = ct.IdPhieuMuon AND ct.IdSach = s.IdSach AND dg.Cmnd LIKE N'%{cmnd}%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }



        public int Insert(PhieuMuonDTO phieuMuon)
        {
            try
            {
                connection.Open();
                string sql = "INSERT INTO PhieuMuon(IdDocGia, NgayMuon, NgayTraLyThuyet, TienCoc)" +
                    " OUTPUT INSERTED.IdPhieuMuon" +
                    " VALUES(@idDocGia, @ngayMuon, @ngayTraLyThuyet, @tienCoc)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idDocGia", phieuMuon.IdDocGia);
                command.Parameters.AddWithValue("@ngayMuon", phieuMuon.NgayMuon);
                command.Parameters.AddWithValue("@ngayTraLyThuyet", phieuMuon.NgayTraLyThuyet);
                command.Parameters.AddWithValue("@tienCoc", phieuMuon.TienCoc);
                
                return (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return -1;
        }

        public bool Update(PhieuMuonDTO phieuMuon)
        {
            try
            {
                connection.Open();
                string sql = "UPDATE PhieuMuon SET IdDocGia = @idDocGia, NgayMuon = @ngayMuon, NgayTraLyThuyet = @ngayTraLyThuyet, NgayTraThucTe = @ngayTraThucTe, TienCoc = @tienCoc WHERE IdPhieuMuon = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idDocGia", phieuMuon.IdDocGia);
                command.Parameters.AddWithValue("@ngayMuon", phieuMuon.NgayMuon);
                command.Parameters.AddWithValue("@ngayTraLyThuyet", phieuMuon.NgayTraLyThuyet);
                command.Parameters.AddWithValue("@ngayTraThucTe", phieuMuon.NgayTraThucTe);
                command.Parameters.AddWithValue("@id", phieuMuon.IdPhieuMuon);
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

        public bool UpdateDayRelease(int id,DateTime d)
        {
            try
            {
                connection.Open();
                string sql = "UPDATE PhieuMuon SET NgayTraThucTe = @ngayTraThucTe WHERE IdDocGia = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ngayTraThucTe", d);
                command.Parameters.AddWithValue("@id", id);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public bool Delete(PhieuMuonDTO phieuMuon)
        {
            try
            {
                connection.Open();
                string sql = "DELETE FROM PhieuMuon WHERE IdPhieuMuon = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", phieuMuon.IdPhieuMuon);
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

        public bool IsExist(PhieuMuonDTO phieuMuon)
        {
            try
            {
                connection.Open();
                string sql = "SELECT * FROM PhieuMuon WHERE IdPhieuMuon = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", phieuMuon.IdPhieuMuon);
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
    }
}
