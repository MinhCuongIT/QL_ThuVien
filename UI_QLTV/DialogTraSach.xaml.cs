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
    /// Interaction logic for DialogTraSach.xaml
    /// </summary>
    public partial class DialogTraSach : Window
    {
        #region Properties
        private int idDocGia;
        private string tenDocGia;
        private DataTable dataTable = new DataTable();
        #endregion
        public DialogTraSach(int id, string name)
        {
            InitializeComponent();
            this.idDocGia = id;
            this.tenDocGia = name;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        #region Methods
        private void LoadData()
        {
            dataTable = new PhieuMuonBUS().GetDataByIdDocGia(this.idDocGia);
            this.txtTenDocGia.Text = this.tenDocGia;
            this.txtIdDocGia.Text = this.idDocGia.ToString();
            this.txtNgayMuon.Text = this.dataTable.Rows[0]["NgayMuon"].ToString();
            this.txtNgayTraLyThuyet.Text = this.dataTable.Rows[0]["NgayTraLyThuyet"].ToString();
            this.txtTienCoc.Text = this.dataTable.Rows[0]["TienCoc"].ToString();
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.dpNgayTraThucTe.Text))
            {
                MessageBox.Show("Vui lòng chọn ngày trả thực tế!");
                return;
            }
            try
            {
                DateTime ngayMuon = (DateTime)this.dataTable.Rows[0]["NgayMuon"];
                DateTime ngayTraLyThuyet = (DateTime)this.dataTable.Rows[0]["NgayTraLyThuyet"];
                DateTime ngayTraThucTe = this.dpNgayTraThucTe.SelectedDate.Value.Date;
                int c = DateTime.Compare(ngayMuon, ngayTraThucTe);
                if (c > 0)
                {
                    MessageBox.Show("Ngày trả thực tế không hơp lệ.\nVui lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                int c2 = DateTime.Compare(ngayTraThucTe, ngayTraLyThuyet);
                new PhieuMuonBUS().UpdateDayRelease(this.idDocGia, ngayTraThucTe);
                if (c2 < 0)
                {
                    MessageBox.Show("Sách trả đúng thời hạn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Sách trả trễ hạn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi!\n" + ex.Message);
            }

        }
    }
}
