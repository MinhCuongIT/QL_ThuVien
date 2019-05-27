using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
    public class TaiKhoanDTO
    {
        private int idTaiKhoan;
        private string username;
        private string password;
        private string tenHienThi;
        private int vaiTro;

        public TaiKhoanDTO()
        {
        }

        public TaiKhoanDTO(int idTaiKhoan, string username, string password, string tenHienThi, int vaiTro)
        {
            this.idTaiKhoan = idTaiKhoan;
            this.username = username;
            this.password = password;
            this.tenHienThi = tenHienThi;
            this.vaiTro = vaiTro;
        }

        public int IdTaiKhoan { get => idTaiKhoan; set => idTaiKhoan = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string TenHienThi { get => tenHienThi; set => tenHienThi = value; }
        public int VaiTro { get => vaiTro; set => vaiTro = value; }
    }
}
