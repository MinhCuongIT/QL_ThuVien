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
    public class LoaiSachDAO : DBConnection
    {
        public DataTable GetAllData()
        {
            string sql = "SELECT * FROM LoaiSach";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public bool Insert(LoaiSachDTO loaiSach)
        {
            try
            {
                connection.Open();
                string sql = "INSERT INTO LoaiSach(TenLoaiSach) VALUES(@tenLoaiSach)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tenLoaiSach", loaiSach.TenLoaiSach);
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

        public bool Update(LoaiSachDTO loaiSach)
        {
            try
            {
                connection.Open();
                string sql = "UPDATE LoaiSach SET TenLoaiSach = @tenLoaiSach WHERE IdLoaiSach = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tenLoaiSach", loaiSach.TenLoaiSach);
                command.Parameters.AddWithValue("@id", loaiSach.IdLoaiSach);
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

        public bool Delete(LoaiSachDTO loaiSach)
        {
            try
            {
                connection.Open();
                string sql = "DELETE FROM LoaiSach WHERE IdLoaiSach = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", loaiSach.IdLoaiSach);
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

        public bool IsExist(LoaiSachDTO loaiSach)
        {
            try
            {
                connection.Open();
                string sql = "SELECT * FROM LoaiSach WHERE TenLoaiSach = @tenLoaiSach";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tenLoaiSach", loaiSach.TenLoaiSach);
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