using BUS_QLTV;
using DTO_QLTV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI_QLTV
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private TaiKhoanDTO currTaiKhoan;

        public TaiKhoanDTO CurrTaiKhoan { get => currTaiKhoan;}

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LblGuessLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Đăng nhập với chế độ public");
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtUsername.Text == "" || this.txtPassword.Password == "")
            {
                MessageBox.Show("Tên tài khoản và mật khẩu không được rỗng!\nVui lòng kiểm tra lại.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            try
            {
                TaiKhoanDTO taiKhoan = new TaiKhoanDTO() {
                    Username = this.txtUsername.Text,
                    Password = this.txtPassword.Password,
                };
                if (new TaiKhoanBUS().IsExist(taiKhoan) )
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    DataTable dt = new TaiKhoanBUS().GetAccountByUsername(this.txtUsername.Text);
                    taiKhoan.IdTaiKhoan = (int)dt.Rows[0]["IdTaiKhoan"];
                    taiKhoan.Password = dt.Rows[0]["Password"].ToString();
                    taiKhoan.TenHienThi = dt.Rows[0]["TenHienThi"].ToString();
                    taiKhoan.VaiTro = (bool)dt.Rows[0]["VaiTro"];

                    this.currTaiKhoan = taiKhoan;
                    MainWindow mainWindow = new MainWindow(this);
                    mainWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sự cố kết nối\n" + ex.Message);
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Threading.Dispatcher.ExitAllFrames();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtUsername.Focus();
        }

        private void TxtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnLogin_Click(null, null);
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnLogin_Click(null, null);
            }
        }
    }
}
