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
    /// Màn hình quản lý loại sách
    /// </summary>
    public partial class LoaiSachWindow : Window
    {
        #region Properties
        /// <summary>
        /// Đối tượng cho phép tương tác với CSDL
        /// </summary>
        private LoaiSachBUS loaiSachBUS = new LoaiSachBUS();

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
        public LoaiSachWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Tải dữ liệu lên grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
       
        /// <summary>
        /// Xử lý thêm một loại sách vào hệ thống
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            LoaiSachDTO loaiSach = new LoaiSachDTO() {
                TenLoaiSach = this.txtLoaiSach.Text
            };
            try
            {
                if (this.loaiSachBUS.Insert(loaiSach))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData();
                    this.txtLoaiSach.Clear();
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
        /// Xử lý thêm một loại sách trong hệ thống
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
                LoaiSachDTO loaiSach = new LoaiSachDTO()
                {
                    IdLoaiSach = (int)this.dt.Rows[this.currIndex]["IdLoaiSach"],
                    TenLoaiSach = this.txtLoaiSach.Text
                };
                try
                {
                    if (this.loaiSachBUS.Update(loaiSach))
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadData();
                    this.txtLoaiSach.Clear();
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
        /// Xử lý xóa một Loại sách trong hệ thống
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
            if (MessageBox.Show("Việc xóa loại sách sẽ bao gồm việc việc xóa tất cả các sách.\nBạn có chắc chắn không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                LoaiSachDTO loaiSach = new LoaiSachDTO()
                {
                    IdLoaiSach = (int)this.dt.Rows[this.currIndex]["IdLoaiSach"],
                    TenLoaiSach = this.txtLoaiSach.Text
                };
                if (this.loaiSachBUS.Delete(loaiSach))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData();
                    this.currIndex = -1;
                    this.txtLoaiSach.Clear();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Xử lý điền thông tin vào textbox khi người dùng click vào phần tử trên grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgLoaiSach_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgLoaiSach.Items.IndexOf(this.dgLoaiSach.CurrentItem) >= 0)
            {
                this.currIndex = this.dgLoaiSach.Items.IndexOf(this.dgLoaiSach.CurrentItem);
                this.txtLoaiSach.Text = this.dt.Rows[this.currIndex]["TenLoaiSach"].ToString();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Thực hiện tải dữ liệu từ CSDL
        /// </summary>
        private void LoadData()
        {
            this.dt = this.loaiSachBUS.GetAllData();
            this.dgLoaiSach.ItemsSource = dt.DefaultView;
            this.dgLoaiSach.Columns[0].IsReadOnly = true;
            this.dgLoaiSach.Columns[0].Header = "#";
            this.dgLoaiSach.Columns[1].Header = "Loại sách";
        }
        #endregion

    }
}
