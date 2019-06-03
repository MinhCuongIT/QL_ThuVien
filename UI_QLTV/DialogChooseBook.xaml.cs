using BUS_QLTV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for DialogChooseBook.xaml
    /// </summary>
    public partial class DialogChooseBook : Window
    {
        #region Properties
        /// <summary>
        /// Đối tượng lưu giữ nghiệp vụ sách
        /// </summary>
        private SachBUS sachBUS = new SachBUS();

        DataTable dt;

        /// <summary>
        /// Đối tượng lưu giữ giá trị id sách người dùng chọn
        /// </summary>
        public int idSach = -1;
        /// <summary>
        /// Số lượng quyển có một quyển đọc giả mượn
        /// </summary>
        public int soLuong = 1;
        /// <summary>
        /// Lính canh nếu bấm ok thì không cần phải confirm
        /// </summary>
        bool IsCancel = false;
        public string tenSach = string.Empty;
        #endregion

        #region Constructor
        /// <summary>
        /// Phương thức khởi tạo mặc định
        /// </summary>
        public DialogChooseBook()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Tải dữ liệu khi form được load lên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dt = sachBUS.GetAllData();
            this.dgBooks.ItemsSource = dt.DefaultView;
        }


        #endregion

        private void DgBooks_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgBooks.Items.IndexOf(this.dgBooks.CurrentItem) >= 0)
            {
                this.idSach = (int)this.dt.Rows[this.dgBooks.Items.IndexOf(this.dgBooks.CurrentItem)]["IdSach"];
                this.tenSach = this.dt.Rows[this.dgBooks.Items.IndexOf(this.dgBooks.CurrentItem)]["TenSach"].ToString();
            }
        }

        private void BtnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.IsCancel = true;
            this.DialogResult = false;
        }

        private void BtnDongY_Click(object sender, RoutedEventArgs e)
        {
            if (this.idSach == -1)
            {
                MessageBox.Show("Bạn chưa chọn sách!\nVui lòng chọn một quyển sách.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            this.DialogResult = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.idSach != -1 && IsCancel)
            {
                var q = MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (q == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void TxtSoLuongMuon_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtSoLuongMuon.Text))
            {
                this.soLuong = int.Parse(this.txtSoLuongMuon.Text); 
            }
        }

        private void TxtSoLuongMuon_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
