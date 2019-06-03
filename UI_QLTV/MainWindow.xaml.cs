using System;
using System.Collections.Generic;
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
    /// Màn hình quản lý chính
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Đối tượng lưu giữ màn hình Login truyền vào
        /// </summary>
        LoginWindow loginWindow = new LoginWindow();
        #region Constructor
        /// <summary>
        /// Phương thức khởi tạo mặc định
        /// </summary>
        /// <param name="loginWindow"></param>
        public MainWindow(LoginWindow loginWindow)
        {
            this.loginWindow = loginWindow;
            InitializeComponent();
            //Set tiêu đề cho màn hình
            this.Title = "Dashboard - Xin chào " + loginWindow.CurrTaiKhoan.TenHienThi + "!";
            if (!loginWindow.CurrTaiKhoan.VaiTro)
            {
                this.btnQuanLyTaiKhoan.IsEnabled = false;
            }

            //Tạo đồng hồ để bàn
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        #endregion


        #region Events
        /// <summary>
        /// Xử lí hiện đồng hồ để bàn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            string s = DateTime.Now.DayOfWeek.ToString().ToUpper();
            this.txtDate.Content = s + ", " + Convert.ToString(DateTime.Now.Date).Substring(0, 10);
            this.txtTime.Content = Convert.ToString(DateTime.Now.TimeOfDay).Substring(0, 8);
        }

        /// <summary>
        /// Xử lý gọi màn hình login khi đóng màn hình quản lý
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            this.loginWindow.Show();
        }

        /// <summary>
        /// Xử lý gọi màn hình thông tin về phần mềm này
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        /// <summary>
        /// Xử lý gọi màn hình quản lý tài khoản
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuanLyTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            AccountWindow accountWindow = new AccountWindow();
            accountWindow.ShowDialog();
        }

        /// <summary>
        /// Xử lý gọi màn hình quản lý đọc giả
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDocGia_Click(object sender, RoutedEventArgs e)
        {
            DocGiaWindow docGiaWindow = new DocGiaWindow();
            docGiaWindow.ShowDialog();
        }

        /// <summary>
        /// Xử lý gọi màn hình quản lập phiếu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnThongKe_Click(object sender, RoutedEventArgs e)
        {

        }


        /// <summary>
        /// Xử lý gọi màn hình quản lý Sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSach_Click(object sender, RoutedEventArgs e)
        {
            SachWindow sachWindow = new SachWindow();
            sachWindow.ShowDialog();
        }

        /// <summary>
        /// Xử lý gọi màn hình quản lý loại sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLoaiSach_Click(object sender, RoutedEventArgs e)
        {
            LoaiSachWindow loaiSachWindow = new LoaiSachWindow();
            loaiSachWindow.ShowDialog();
        }

        /// <summary>
        /// Xử lý hiện menu khi người dùng nhấn nút
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLapPhieu_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            if (button != null)
            {
                button.ContextMenu.IsOpen = true;
            }
        }

        /// <summary>
        /// Xử lý hiện cửa sổ thực hiện tác vụ cho mượn sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_MuonSach_Click(object sender, RoutedEventArgs e)
        {
            MuonSachWindow muonSachWindow = new MuonSachWindow();
            muonSachWindow.ShowDialog();
        }

        /// <summary>
        /// Xử lý hiện danh sách những người mượn sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_XemDanhSach_Click(object sender, RoutedEventArgs e)
        {
            DanhSachPhieuMuonWindow danhSachPhieuMuonWindow = new DanhSachPhieuMuonWindow();
            danhSachPhieuMuonWindow.ShowDialog();
        }

        /// <summary>
        /// Xử lý thực hiện tác vụ trả lại sách của đọc giả
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_TraLaiSach_Click(object sender, RoutedEventArgs e)
        {
            TraSachWindow traSachWindow = new TraSachWindow();
            traSachWindow.ShowDialog();
        }
        #endregion

    }
}
