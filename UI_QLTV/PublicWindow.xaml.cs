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
    /// Interaction logic for PublicWindow.xaml
    /// </summary>
    public partial class PublicWindow : Window
    {
        private LoginWindow loginWindow;

        public PublicWindow(LoginWindow login)
        {
            InitializeComponent();
            this.loginWindow = login;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int ranInt = random.Next(1000, 10000);
            this.Title = "Xin chào đọc giả " + ranInt+" !";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.loginWindow.Show();
        }

        private void CbLoaiSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnLoc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
