using BUS_QLTV;
using DTO_QLTV;
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
    /// Màn hình quản lý đọc giả
    /// </summary>
    public partial class DocGiaWindow : Window
    {
        #region Properties
        /// <summary>
        /// Đối tượng cho phép tương tác với CSDL
        /// </summary>
        private DocGiaBUS docGiaBUS = new DocGiaBUS();

        /// <summary>
        /// Đối tượng lưu table tài khoản hiện tại
        /// </summary>
        private DataTable dt;

        /// <summary>
        /// Vị trí người dùng click trên datagrid
        /// </summary>
        private int currIndex = -1;
        #endregion

        #region Constructor
        /// <summary>
        /// Phương thức khởi tạo mặc định
        /// </summary>
        public DocGiaWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Xử lý tự động điền vào các field khi người dùng click vào grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgDocGia_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgDocGia.Items.IndexOf(this.dgDocGia.CurrentItem) >= 0)
            {
                this.currIndex = this.dgDocGia.Items.IndexOf(this.dgDocGia.CurrentItem);
                this.txtTenDocGia.Text = this.dt.Rows[this.currIndex]["TenDocGia"].ToString();
                this.txtCmnd.Text = this.dt.Rows[this.currIndex]["Cmnd"].ToString();
                this.txtDiaChi.Text = this.dt.Rows[this.currIndex]["DiaChi"].ToString();
            }
        }

        /// <summary>
        /// Xử lý xóa trống các trường
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            resetAllTexbox();
            this.currIndex = -1;
        }

        /// <summary>
        /// Xử lý xóa một đọc giả trong hệ thống
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (this.currIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đối tượng cần để xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DocGiaDTO docGia = new DocGiaDTO()
                {
                    Id = (int)this.dt.Rows[this.currIndex]["IdDocGia"],
                    TenDocGia = this.txtTenDocGia.Text,
                    Cmnd = this.txtCmnd.Text,
                    DiaChi = this.txtDiaChi.Text,
                };
                if (this.docGiaBUS.Delete(docGia))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData();
                    resetAllTexbox();
                    this.currIndex = -1;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Xử lý cập nhật đọc giả trong hệ thống
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            if (this.currIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đối tượng cần để cập nhật!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DocGiaDTO docGia = new DocGiaDTO()
                {
                    Id = (int)this.dt.Rows[this.currIndex]["IdDocGia"],
                    TenDocGia = this.txtTenDocGia.Text,
                    Cmnd = this.txtCmnd.Text,
                    DiaChi = this.txtDiaChi.Text,
                };
                if (this.docGiaBUS.Update(docGia))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData();
                    resetAllTexbox();
                    this.currIndex = -1;
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Xử lý thêm đọc giả trong hệ thống
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            DocGiaDTO docGia = new DocGiaDTO()
            {
                TenDocGia = this.txtTenDocGia.Text,
                Cmnd = this.txtCmnd.Text,
                DiaChi = this.txtDiaChi.Text,
            };
            try
            {
                if (this.docGiaBUS.Insert(docGia))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData();
                    resetAllTexbox();
                    this.currIndex = -1;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm!\n" + ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// Xử lý tải dữ liệu lên màn hình
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }


        #endregion

        #region Methods
        /// <summary>
        /// Xử lý tải dữ liệu từ dưới CSDL
        /// </summary>
        private void LoadData()
        {
            this.dt = this.docGiaBUS.GetAllData();
            this.dgDocGia.ItemsSource = dt.DefaultView;
            this.dgDocGia.Columns[0].IsReadOnly = true;
            this.dgDocGia.Columns[0].Header = "#";
            this.dgDocGia.Columns[1].Header = "Tên đọc giả";
            this.dgDocGia.Columns[2].Header = "Chứng minh nhân dân";
            this.dgDocGia.Columns[3].Header = "Địa chỉ";
        }

        /// <summary>
        /// Xử lý xóa trống các trường trong grid
        /// </summary>
        private void resetAllTexbox()
        {
            this.txtCmnd.Clear();
            this.txtDiaChi.Clear();
            this.txtTenDocGia.Clear();
        }
        #endregion

        private void TxtCmnd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
