using BUS_QLTV;
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
    /// Interaction logic for DanhSachPhieuMuonWindow.xaml
    /// </summary>
    public partial class DanhSachPhieuMuonWindow : Window
    {
        public DanhSachPhieuMuonWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.dgAllData.ItemsSource = new PhieuMuonBUS().GetAllData().DefaultView;
            this.dgAllData.Columns[0].Header = "Tên đọc giả";
            this.dgAllData.Columns[1].Header = "Ngày mượn";
            this.dgAllData.Columns[2].Header = "Ngày dự kiến trả";
            this.dgAllData.Columns[3].Header = "Tiền đọc giả cọc";
            this.dgAllData.Columns[4].Header = "Tên sách";
            this.dgAllData.Columns[5].Header = "Số lượng mượn";
            this.dgAllData.Columns[6].Visibility =Visibility.Hidden;
        }
    }
}
