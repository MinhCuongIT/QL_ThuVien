using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
    public class TaiKhoanDTO
    {
        private int taikhoan;
        private string username;
        private string password;
        private string tenHienThi;
        private int vaiTro;

        public TaiKhoanDTO()
        {
        }

        public TaiKhoanDTO(int taikhoan, string username, string password, string tenHienThi, int vaiTro)
        {
            this.taikhoan = taikhoan;
            this.username = username;
            this.password = password;
            this.tenHienThi = tenHienThi;
            this.vaiTro = vaiTro;
        }

        public int Taikhoan { get => taikhoan; set => taikhoan = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string TenHienThi { get => tenHienThi; set => tenHienThi = value; }
        public int VaiTro { get => vaiTro; set => vaiTro = value; }
    }
}
