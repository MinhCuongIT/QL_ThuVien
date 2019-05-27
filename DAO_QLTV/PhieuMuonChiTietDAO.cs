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
    public class PhieuMuonChiTietDAO : DBConnection
    {
        public DataTable GetAllData()
        {
            string sql = "SELECT * FROM PhieuMuonChiTiet";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public bool Insert(PhieuMuonChiTietDTO phieuMuonChiTiet)
        {
            try
            {
                connection.Open();
                string sql = "INSERT INTO PhieuMuonChiTiet(IdPhieuMuon, IdSach, SoLuongMuon) VALUES(@idPhieuMuon, @idSach, @soLuongMuon)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idPhieuMuon", phieuMuonChiTiet.IdPhieuMuon);
                command.Parameters.AddWithValue("@idSach", phieuMuonChiTiet.IdSach);
                command.Parameters.AddWithValue("@soLuongMuon", phieuMuonChiTiet.SoLuongMuon);
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

        public bool Update(PhieuMuonChiTietDTO phieuMuonChiTiet)
        {
            try
            {
                connection.Open();
                string sql = "UPDATE PhieuMuonChiTiet SET IdPhieuMuon = @idPhieuMuon, IdSach = @idSach, SoLuongMuon = @soLuongMuon WHERE IdPhieuMuonChiTiet = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idPhieuMuon", phieuMuonChiTiet.IdPhieuMuon);
                command.Parameters.AddWithValue("@idSach", phieuMuonChiTiet.IdSach);
                command.Parameters.AddWithValue("@soLuongMuon", phieuMuonChiTiet.SoLuongMuon);
                command.Parameters.AddWithValue("@id", phieuMuonChiTiet.Id);
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

        public bool Delete(PhieuMuonChiTietDTO phieuMuonChiTiet)
        {
            try
            {
                connection.Open();
                string sql = "DELETE FROM PhieuMuonChiTiet WHERE IdPhieuMuonChiTiet = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", phieuMuonChiTiet.Id);
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

        public bool IsExist(PhieuMuonChiTietDTO phieuMuonChiTiet)
        {
            try
            {
                connection.Open();
                string sql = "SELECT * FROM PhieuMuonChiTiet WHERE IdPhieuMuonChiTiet = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", phieuMuonChiTiet.Id);
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
