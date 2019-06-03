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
    /// Interaction logic for TraSachWindow.xaml
    /// </summary>
    public partial class TraSachWindow : Window
    {
        #region Properties
        /// <summary>
        /// Table chứa dữ liệu tìm kiếm
        /// </summary>
        DataTable tableSearch;
        #endregion
        public TraSachWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.tableSearch = new PhieuMuonBUS().GetAllData();
            this.dgSearch.ItemsSource = this.tableSearch.DefaultView;
            this.dgSearch.Columns[0].Header = "Tên đọc giả";
            this.dgSearch.Columns[1].Header = "Ngày mượn";
            this.dgSearch.Columns[2].Header = "Ngày dự kiến trả";
            this.dgSearch.Columns[3].Header = "Tiền đọc giả cọc";
            this.dgSearch.Columns[4].Header = "Tên sách";
            this.dgSearch.Columns[5].Header = "Số lượng mượn";
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

            if (this.rbCmnd.IsChecked == true)
            {
                //Tìm kiếm theo CMND
                this.tableSearch = new PhieuMuonBUS().SearchByCmnd(this.txtSearch.Text);
                this.dgSearch.ItemsSource = tableSearch.DefaultView;
                this.dgSearch.Columns[0].Header = "Tên đọc giả";
                this.dgSearch.Columns[1].Header = "Ngày mượn";
                this.dgSearch.Columns[2].Header = "Ngày dự kiến trả";
                this.dgSearch.Columns[3].Header = "Tiền đọc giả cọc";
                this.dgSearch.Columns[4].Header = "Tên sách";
                this.dgSearch.Columns[5].Header = "Số lượng mượn";
                this.dgSearch.Columns[6].Visibility = Visibility.Hidden;
            }
            else
            {
                //Tìm kiếm theo tên
                this.tableSearch = new PhieuMuonBUS().SearchByName(this.txtSearch.Text);
                this.dgSearch.ItemsSource = tableSearch.DefaultView;
                this.dgSearch.Columns[0].Header = "Tên đọc giả";
                this.dgSearch.Columns[1].Header = "Ngày mượn";
                this.dgSearch.Columns[2].Header = "Ngày dự kiến trả";
                this.dgSearch.Columns[3].Header = "Tiền đọc giả cọc";
                this.dgSearch.Columns[4].Header = "Tên sách";
                this.dgSearch.Columns[5].Header = "Số lượng mượn";
                this.dgSearch.Columns[6].Visibility = Visibility.Hidden;
            }
        }

        private void DgSearch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = dgSearch.SelectedIndex;
            if (index >= 0)
            {
                int idDocGia = (int)this.tableSearch.Rows[index]["IdDocGia"];
                string name = this.tableSearch.Rows[index]["TenDocGia"].ToString();
                DialogTraSach dialogTraSach = new DialogTraSach(idDocGia, name);
                dialogTraSach.ShowDialog();
            }
        }
    }
}
