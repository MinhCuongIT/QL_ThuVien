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
    /// Màn hình quản lý tải khoản của hệ thống
    /// </summary>
    public partial class AccountWindow : Window
    {
        #region Properties
        /// <summary>
        /// Đối tượng cho phép tương tác với CSDL
        /// </summary>
        private TaiKhoanBUS taiKhoanBUS = new TaiKhoanBUS();

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
        /// Hàm dựng mặc định
        /// </summary>
        public AccountWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Events
        /// <summary>
        /// Thực hiện tải dữ liệu lên màn hình
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Xử lí điền thông tin khi người dùng click vào grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgAccounts_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgAccounts.Items.IndexOf(this.dgAccounts.CurrentItem) >= 0)
            {
                this.currIndex = this.dgAccounts.Items.IndexOf(this.dgAccounts.CurrentItem);
                this.txtUsername.Text = this.dt.Rows[this.currIndex]["Username"].ToString();
                this.txtPassword.Text = this.dt.Rows[this.currIndex]["Password"].ToString();
                this.txtTenHienThi.Text = this.dt.Rows[this.currIndex]["TenHienThi"].ToString();
                if ((bool)this.dt.Rows[this.currIndex]["VaiTro"])
                {
                    this.rbAdmin.IsChecked = true;
                }
                else
                {
                    this.rbThuThu.IsChecked = true;
                }
            }
        }

        /// <summary>
        /// Xử lý thêm tài khoản
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            bool isAdmin = false;
            if ((this.rbAdmin.IsChecked).HasValue && (this.rbAdmin.IsChecked).Value)
            {
                isAdmin = true;
            }
            TaiKhoanDTO obj = new TaiKhoanDTO()
            {
                Username = this.txtUsername.Text,
                Password = this.txtPassword.Text,
                TenHienThi = this.txtTenHienThi.Text,
                VaiTro = isAdmin
            };
            try
            {
                if (this.taiKhoanBUS.Insert(obj))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetAllTextbox();
                    LoadData();
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
        /// Xử lý cập nhật tài khoản
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
                bool isAdmin = false;
                if ((this.rbAdmin.IsChecked).HasValue && (this.rbAdmin.IsChecked).Value)
                {
                    isAdmin = true;
                }
                TaiKhoanDTO obj = new TaiKhoanDTO()
                {
                    IdTaiKhoan = (int)this.dt.Rows[this.currIndex]["IdTaiKhoan"],
                    Username = this.txtUsername.Text,
                    Password = this.txtPassword.Text,
                    TenHienThi = this.txtTenHienThi.Text,
                    VaiTro = isAdmin
                };
                try
                {
                    if (this.taiKhoanBUS.Update(obj))
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetAllTextbox();
                        LoadData();
                        this.currIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể cập nhật!\n" + ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    throw;
                }
            }
        }
        /// <summary>
        /// Xử lý xóa tài khoản
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
            if (this.txtUsername.Text.Equals("admin"))
            {
                MessageBox.Show("Bạn không thể xóa quản trị viên này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                TaiKhoanDTO obj = new TaiKhoanDTO()
                {
                    IdTaiKhoan = (int)this.dt.Rows[this.currIndex]["IdTaiKhoan"],
                    Username = this.txtUsername.Text,
                    Password = this.txtPassword.Text,
                    TenHienThi = this.txtTenHienThi.Text,
                };
                if (this.taiKhoanBUS.Delete(obj))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    resetAllTextbox();
                    LoadData();
                    this.currIndex = -1;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Xử lý xóa trống các trường để nhập lại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            resetAllTextbox();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Thực hiện tải dữ liệu từ dưới CSDL lên grid
        /// </summary>
        private void LoadData()
        {
            this.dt = taiKhoanBUS.GetAllData();
            this.dgAccounts.ItemsSource = dt.DefaultView;
            this.dgAccounts.Columns[0].IsReadOnly = true;
            this.dgAccounts.Columns[0].Header = "#";
            this.dgAccounts.Columns[1].Header = "Tên đăng nhập";
            this.dgAccounts.Columns[2].Header = "Mật khẩu";
            this.dgAccounts.Columns[3].Header = "Tên hiển thị";
            this.dgAccounts.Columns[4].Header = "Administrator";
        }

        /// <summary>
        /// Xóa trống các trường dữ liệu
        /// </summary>
        private void resetAllTextbox()
        {
            this.txtUsername.Clear();
            this.txtPassword.Clear();
            this.txtTenHienThi.Clear();
            this.rbAdmin.IsChecked = false;
            this.rbThuThu.IsChecked = false;
        }
        #endregion

    }
}
