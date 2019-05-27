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
    public class DocGiaDAO : DBConnection
    {
        public DataTable GetAllData()
        {
            string sql = "SELECT * FROM DocGia";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public bool Insert(DocGiaDTO docGia)
        {
            try
            {
                connection.Open();
                string sql = "INSERT INTO DocGia(TenDocGia, Cmnd, DiaChi) VALUES(@tenDocGia, @cmnd, @diaChi)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tenDocGia", docGia.TenDocGia);
                command.Parameters.AddWithValue("@cmnd", docGia.Cmnd);
                command.Parameters.AddWithValue("@diaChi", docGia.DiaChi);
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

        public bool Update(DocGiaDTO docGia)
        {
            try
            {
                connection.Open();
                string sql = "UPDATE DocGia SET TenDocGia = @tenDocGia, Cmnd = @cmnd, DiaChi = @diaChi WHERE IdDocGia = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tenDocGia", docGia.TenDocGia);
                command.Parameters.AddWithValue("@cmnd", docGia.Cmnd);
                command.Parameters.AddWithValue("@diaChi", docGia.DiaChi);
                command.Parameters.AddWithValue("@id", docGia.Id);
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

        public bool Delete(DocGiaDTO docGia)
        {
            try
            {
                connection.Open();
                string sql = "DELETE FROM DocGia WHERE IdDocGia = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", docGia.Id);
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

        public bool IsExist(DocGiaDTO docGia)
        {
            try
            {
                connection.Open();
                string sql = "SELECT * FROM DocGia WHERE Cmnd = @cmnd";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@cmnd", docGia.Cmnd);
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