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

using System.Text.RegularExpressions;


namespace UI_QLTV
{
    /// <summary>
    /// Interaction logic for SachWindow.xaml
    /// </summary>
    public partial class SachWindow : Window
    {
        #region Properties
        /// <summary>
        /// Biến Lưu giữ IdLoaiSach
        /// </summary>
        int currIdLoaiSach = -1;

        /// <summary>
        /// Lưu vị trí hiện tại của người dùng khi click vào bảng
        /// </summary>
        private int currIndex = -1;

        /// <summary>
        /// Đối tượng cho phép thực hiện các nghiệp vụ sách
        /// </summary>
        private SachBUS sachBUS = new SachBUS();

        /// <summary>
        /// Đối tượng cho phép thực hiện tham chiếu nghiệp vụ Loại Sách
        /// </summary>
        private LoaiSachBUS loaiSachBUS = new LoaiSachBUS();

        /// <summary>
        /// Đối tượng lưu giá trị hiển thị lên bảng sách
        /// </summary>
        DataTable dt;
        #endregion

        #region Constructor
        /// <summary>
        /// Phương thức khởi tạo mặc định
        /// </summary>
        public SachWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Xử lý thêm một quyển sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SachDTO sach = new SachDTO()
                {
                    IdLoaiSach = this.currIdLoaiSach,
                    TenSach = this.txtTenSach.Text,
                    NgonNgu = this.txtNgonNgu.Text,
                    NhaXuatBan = this.txtNhaXuatBan.Text,
                    NgayNhap = this.dpNgayNhap.Text,
                    GiaTien = int.Parse(this.txtGiaTien.Text),
                    SoLuongTong = int.Parse(this.txtSoLuongTong.Text),
                    SoLuongConLai = int.Parse(this.txtSoLuongConLai.Text)
                };

                if (this.sachBUS.Insert(sach))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    ResetAllTextbox();
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
        /// Xử lý cập nhật một quyển sách
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
                SachDTO sach = new SachDTO()
                {
                    Id = (int)this.dt.Rows[this.currIndex]["IdSach"],
                    IdLoaiSach = this.currIdLoaiSach,
                    TenSach = this.txtTenSach.Text,
                    NgonNgu = this.txtNgonNgu.Text,
                    NhaXuatBan = this.txtNhaXuatBan.Text,
                    NgayNhap = this.dpNgayNhap.Text,
                    GiaTien = int.Parse(this.txtGiaTien.Text),
                    SoLuongTong = int.Parse(this.txtSoLuongTong.Text),
                    SoLuongConLai = int.Parse(this.txtSoLuongConLai.Text)
                };
                try
                {
                    if (this.sachBUS.Update(sach))
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ResetAllTextbox();
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
        /// Xử lý xóa một quyển sách
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
                SachDTO sach = new SachDTO()
                {
                    Id = (int)this.dt.Rows[this.currIndex]["IdSach"],
                    IdLoaiSach = this.currIdLoaiSach,
                    TenSach = this.txtTenSach.Text,
                    NgonNgu = this.txtNgonNgu.Text,
                    NhaXuatBan = this.txtNhaXuatBan.Text,
                    NgayNhap = this.dpNgayNhap.Text,
                    GiaTien = int.Parse(this.txtGiaTien.Text),
                    SoLuongTong = int.Parse(this.txtSoLuongTong.Text),
                    SoLuongConLai = int.Parse(this.txtSoLuongConLai.Text)
                };
                if (this.sachBUS.Delete(sach))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    ResetAllTextbox();
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
        /// Xử lý xóa trống các trường 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetAllTextbox();
        }

        /// <summary>
        /// Xử lí tải dữ liệu khi màn hình được tải
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Điền dữ liệu cho combobox
            DataTable dtLoaiSach = loaiSachBUS.GetAllData();
            DataRow dr = dtLoaiSach.NewRow();
            dr["IdLoaiSach"] = 0;
            dr["TenLoaiSach"] = "Tất cả";
            dtLoaiSach.Rows.Add(dr);
            this.cbLoaiSach.ItemsSource = dtLoaiSach.DefaultView;
            this.cbLoaiSach.DisplayMemberPath = "TenLoaiSach";
            this.cbLoaiSach.SelectedValuePath = "IdLoaiSach";
        }

        /// <summary>
        /// Thực hiện điền dữ liệu vào trong các trường khi người dùng click lên grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgSach_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgSach.Items.IndexOf(this.dgSach.CurrentItem) >= 0)
            {
                this.currIndex = this.dgSach.Items.IndexOf(this.dgSach.CurrentItem);

                this.txtTenLoaiSach.Text = this.dt.Rows[this.currIndex]["TenLoaiSach"].ToString();
                this.txtTenSach.Text = this.dt.Rows[this.currIndex]["TenSach"].ToString();
                this.txtNgonNgu.Text = this.dt.Rows[this.currIndex]["NgonNgu"].ToString();
                this.txtNhaXuatBan.Text = this.dt.Rows[this.currIndex]["NhaXuatBan"].ToString();
                this.dpNgayNhap.Text = this.dt.Rows[this.currIndex]["NgayNhap"].ToString();
                this.txtTenSach.Text = this.dt.Rows[this.currIndex]["TenSach"].ToString();
                this.txtGiaTien.Text = this.dt.Rows[this.currIndex]["GiaTien"].ToString();
                this.txtSoLuongTong.Text = this.dt.Rows[this.currIndex]["SoLuongTong"].ToString();
                this.txtSoLuongConLai.Text = this.dt.Rows[this.currIndex]["SoLuongConLai"].ToString();

                this.currIdLoaiSach = (int)this.dt.Rows[this.currIndex]["IdLoaiSach"];
            }
        }

        /// <summary>
        /// Xử lý đổ dữ liệu lên grid tương ứng với dữ liệu trong combox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbLoaiSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Xử lý chỉ cho phép nhập số
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtGiaTien_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Xử lý chỉ cho phép nhập số
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSoLuongTong_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Xử lý chỉ cho phép nhập số
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSoLuongConLai_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion

        #region Methods
        private void ResetAllTextbox()
        {
            this.currIndex = -1;
            this.currIdLoaiSach = -1;

            this.txtTenSach.Clear();
            this.txtNgonNgu.Clear();
            this.txtNhaXuatBan.Clear();
            this.dpNgayNhap.Text = string.Empty;
            this.txtTenSach.Clear();
            this.txtGiaTien.Clear();
            this.txtSoLuongTong.Clear();
            this.txtSoLuongConLai.Clear();
        }

        private void LoadData()
        {
            this.txtTenLoaiSach.Clear();
            if (this.cbLoaiSach.SelectedValue.Equals(0))
            {
                //Trường hợp hiện tất cả lên grid
                this.btnThem.IsEnabled = false;
                this.dt = this.sachBUS.GetAllData();
                LoadDataDetails();
            }
            else
            {
                //Trường hợp chỉ hiện sách theo loại sách nào đó
                this.btnThem.IsEnabled = true;
                this.dt = this.sachBUS.GetSachByLoaiSach((int)this.cbLoaiSach.SelectedValue);
                LoadDataDetails();
                this.txtTenLoaiSach.Text = (this.cbLoaiSach.SelectedItem as DataRowView).Row["TenLoaiSach"] as string;
                this.currIdLoaiSach = (int)this.cbLoaiSach.SelectedValue;
            }
        }

        private void LoadDataDetails()
        {
            this.dgSach.ItemsSource = this.dt.DefaultView;
            this.dgSach.Columns[0].Visibility = Visibility.Hidden;
            this.dgSach.Columns[1].Header = "Tên loại sách";
            this.dgSach.Columns[2].Header = "Tên sách";
            this.dgSach.Columns[3].Header = "Ngôn ngữ";
            this.dgSach.Columns[4].Header = "Nhà xuất bản";
            this.dgSach.Columns[5].Header = "Ngày nhập";
            this.dgSach.Columns[6].Header = "Giá tiền";
            this.dgSach.Columns[7].Header = "Số lượng tổng";
            this.dgSach.Columns[8].Header = "Số lượng còn lại";
            this.dgSach.Columns[9].Visibility = Visibility.Hidden;
        }
        #endregion


    }
}
