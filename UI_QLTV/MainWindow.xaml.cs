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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginWindow loginWindow = new LoginWindow();
        public MainWindow(LoginWindow loginWindow)
        {
            this.loginWindow = loginWindow;
            InitializeComponent();
            //Set tiêu đề cho màn hình
            this.Title = "Dashboard - Xin chào " + loginWindow.CurrTaiKhoan.TenHienThi + "!";
            if (loginWindow.CurrTaiKhoan.VaiTro != 0)
            {
                this.btnQuanLyTaiKhoan.IsEnabled = false;
            }

            //Tạo đồng hồ để bàn
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.loginWindow.Show();
        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
             
        }

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
        #endregion

        private void BtnAbout_Click_1(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }
    }
}
