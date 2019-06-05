using BUS_QLTV;
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
            int ranInt = new Random().Next(1000, 10000);
            this.Title = "Xin chào đọc giả " + ranInt+" !";

            //Điền dữ liệu cho combobox
            DataTable dtLoaiSach = new LoaiSachBUS().GetAllData();
            DataRow dr = dtLoaiSach.NewRow();
            dr["IdLoaiSach"] = 0;
            dr["TenLoaiSach"] = "Tất cả";
            dtLoaiSach.Rows.Add(dr);
            this.cbLoaiSach.ItemsSource = dtLoaiSach.DefaultView;
            this.cbLoaiSach.DisplayMemberPath = "TenLoaiSach";
            this.cbLoaiSach.SelectedValuePath = "IdLoaiSach";

            this.cbLoaiSach.SelectedIndex = dtLoaiSach.Rows.Count;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.loginWindow.Show();
        }

        private void CbLoaiSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.cbLoaiSach.SelectedValue.Equals(0))
            {
                this.dgResutl.ItemsSource = new SachBUS().GetAllData().DefaultView;
                this.dgResutl.Columns[0].Visibility = Visibility.Hidden;
                this.dgResutl.Columns[1].Header = "Tên loại sách";
                this.dgResutl.Columns[2].Header = "Tên sách";
                this.dgResutl.Columns[3].Header = "Ngôn ngữ";
                this.dgResutl.Columns[4].Header = "Nhà xuất bản";
                this.dgResutl.Columns[5].Header = "Ngày nhập";
                this.dgResutl.Columns[6].Header = "Giá tiền";
                this.dgResutl.Columns[7].Visibility = Visibility.Hidden;
                this.dgResutl.Columns[8].Visibility = Visibility.Hidden;
                this.dgResutl.Columns[9].Visibility = Visibility.Hidden;
            }
            else
            {
                this.dgResutl.ItemsSource = new SachBUS().FillByIdLoaiSach((int)this.cbLoaiSach.SelectedValue).DefaultView;
                this.dgResutl.Columns[0].Header = "Mã Loại Sách";
                this.dgResutl.Columns[1].Header = "Tên Loại Sách";
                this.dgResutl.Columns[2].Header = "Mã Loại Sách";
                this.dgResutl.Columns[3].Header = "Tên Loại Sách";
                this.dgResutl.Columns[4].Header = "Ngôn Ngữ";
                this.dgResutl.Columns[5].Header = "Nhà Xuất Bản";
                this.dgResutl.Columns[6].Header = "Ngày Nhập";
                this.dgResutl.Columns[7].Header = "Giá Tiền";
            }
        }

        private void BtnLoc_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        #region Methods
        private void LoadData()
        {
            if (this.rbTenSach.IsChecked == true)
            {
                this.dgResutl.ItemsSource = new SachBUS().FillByTenSach(this.txtSearch.Text).DefaultView;
                this.dgResutl.Columns[0].Header = "Mã Loại Sách";
                this.dgResutl.Columns[1].Header = "Tên Loại Sách";
                this.dgResutl.Columns[2].Header = "Mã Loại Sách";
                this.dgResutl.Columns[3].Header = "Tên Loại Sách";
                this.dgResutl.Columns[4].Header = "Ngôn Ngữ";
                this.dgResutl.Columns[5].Header = "Nhà Xuất Bản";
                this.dgResutl.Columns[6].Header = "Ngày Nhập";
                this.dgResutl.Columns[7].Header = "Giá Tiền";
            }
            if (this.rbNgonNgu.IsChecked == true)
            {
                this.dgResutl.ItemsSource = new SachBUS().FillByNgonNgu(this.txtSearch.Text).DefaultView;
                this.dgResutl.Columns[0].Header = "Mã Loại Sách";
                this.dgResutl.Columns[1].Header = "Tên Loại Sách";
                this.dgResutl.Columns[2].Header = "Mã Loại Sách";
                this.dgResutl.Columns[3].Header = "Tên Loại Sách";
                this.dgResutl.Columns[4].Header = "Ngôn Ngữ";
                this.dgResutl.Columns[5].Header = "Nhà Xuất Bản";
                this.dgResutl.Columns[6].Header = "Ngày Nhập";
                this.dgResutl.Columns[7].Header = "Giá Tiền";
            }
            if (this.rbNhaXuatBan.IsChecked == true)
            {
                this.dgResutl.ItemsSource = new SachBUS().FillByNhaXuatBan(this.txtSearch.Text).DefaultView;
                this.dgResutl.Columns[0].Header = "Mã Loại Sách";
                this.dgResutl.Columns[1].Header = "Tên Loại Sách";
                this.dgResutl.Columns[2].Header = "Mã Loại Sách";
                this.dgResutl.Columns[3].Header = "Tên Loại Sách";
                this.dgResutl.Columns[4].Header = "Ngôn Ngữ";
                this.dgResutl.Columns[5].Header = "Nhà Xuất Bản";
                this.dgResutl.Columns[6].Header = "Ngày Nhập";
                this.dgResutl.Columns[7].Header = "Giá Tiền";
            }
        }
        #endregion
    }
}
