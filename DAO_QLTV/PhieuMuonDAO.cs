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
    class PhieuMuonDAO : DBConnection
    {
        public DataTable GetAllData()
        {
            string sql = "SELECT * FROM PhieuMuon";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public bool Insert(PhieuMuonDTO phieuMuon)
        {
            try
            {
                connection.Open();
                string sql = "INSERT INTO PhieuMuon(IdDocGia, NgayMuon, NgayTraLyThuyet, NgayTraThucTe, TienCoc)" +
                    " VALUES(@idDocGia, @ngayMuon, @ngayTraLyThuyet, @ngayTraThucTe, @tienCoc)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idDocGia", phieuMuon.IdDocGia);
                command.Parameters.AddWithValue("@ngayMuon", phieuMuon.NgayMuon);
                command.Parameters.AddWithValue("@ngayTraLyThuyet", phieuMuon.NgayTraLyThuyet);
                command.Parameters.AddWithValue("@ngayTraThucTe", phieuMuon.NgayTraThucTe);
                command.Parameters.AddWithValue("@tienCoc", phieuMuon.TienCoc);
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
