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
    public class TaiKhoanDAO : DBConnection
    {
        public DataTable GetAllData()
        {
            string sql = "SELECT * FROM TaiKhoan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetAccountByUsername(string username)
        {
            string sql = $"SELECT * FROM TaiKhoan WHERE Username = '{username}'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public bool Insert(TaiKhoanDTO taiKhoan)
        {
            try
            {
                connection.Open();
                string sql = "INSERT INTO TaiKhoan(Username, Password, TenHienThi, vaiTro)" +
                    " VALUES(@username, @password, @tenHienThi, @vaiTro)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", taiKhoan.Username);
                command.Parameters.AddWithValue("@password", taiKhoan.Password);
                command.Parameters.AddWithValue("@tenHienThi", taiKhoan.TenHienThi);
                command.Parameters.AddWithValue("@vaiTro", taiKhoan.VaiTro);
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

        public bool Update(TaiKhoanDTO taiKhoan)
        {
            try
            {
                connection.Open();
                string sql = "UPDATE TaiKhoan SET Username = @username, Password = @password, TenHienThi = @tenHienThi, VaiTro = @vaiTro WHERE IdTaiKhoan = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", taiKhoan.Username);
                command.Parameters.AddWithValue("@password", taiKhoan.Password);
                command.Parameters.AddWithValue("@tenHienThi", taiKhoan.TenHienThi);
                command.Parameters.AddWithValue("@vaiTro", taiKhoan.VaiTro);
                command.Parameters.AddWithValue("@id", taiKhoan.IdTaiKhoan);
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

        public bool Delete(TaiKhoanDTO taiKhoan)
        {
            try
            {
                connection.Open();
                string sql = "DELETE FROM TaiKhoan WHERE IdTaiKhoan = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", taiKhoan.IdTaiKhoan);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public bool IsExist(TaiKhoanDTO taiKhoan)
        {
            try
            {
                connection.Open();
                string sql = "SELECT * FROM TaiKhoan WHERE Username = @username";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", taiKhoan.Username);
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
