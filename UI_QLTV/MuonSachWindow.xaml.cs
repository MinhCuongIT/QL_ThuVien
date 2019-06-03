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
    /// Interaction logic for MuonSachWindow.xaml
    /// </summary>
    public partial class MuonSachWindow : Window
    {
        #region Properties

        /// <summary>
        /// Đối tượng xử lý nghiệp vụ dọc giả
        /// </summary>
        DocGiaBUS docGiaBUS = new DocGiaBUS();

        /// <summary>
        /// Bảng lưu đọc giả
        /// </summary>
        DataTable tableDocGia;

        /// <summary>
        /// Bảng lưu sách
        /// </summary>
        DataTable tableBooks = new DataTable();

        /// <summary>
        /// Lưu giá trị hiện tại khi người click vào grid
        /// </summary>
        private int currIndex = -1;

        #endregion

        #region Constructor
        /// <summary>
        /// Phương thức khởi tạo mặc định
        /// </summary>
        public MuonSachWindow()
        {
            InitializeComponent();
        }
        #endregion


        #region Events
        /// <summary>
        /// Xử lí tải dữ liệu ngầm khi form được load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tableDocGia = docGiaBUS.GetAllData();
            this.cbDocGia.ItemsSource = tableDocGia.DefaultView;
            this.cbDocGia.DisplayMemberPath = "TenDocGia";
            this.cbDocGia.SelectedValuePath = "IdDocGia";

            tableBooks.Columns.Add("Mã sách");
            tableBooks.Columns.Add("Tên sách");
            tableBooks.Columns.Add("Số lượng");
            LoadData();
        }

        /// <summary>
        /// Xử lý ẩn màn hình khi người dùng không muốn xuất phiếu nữa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHuyPhieu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Xử lý xuất phiếu mượn sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnXuatPhieu_Click(object sender, RoutedEventArgs e)
        {

            if (this.cbDocGia.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn đọc giả!");
                return;
            }
            if (tinhTongSoLuong() == 0)
            {
                MessageBox.Show("Không có sách mượn!");
                return;
            }
            if (string.IsNullOrEmpty(this.dpNgayMuon.Text) ||
                string.IsNullOrEmpty(this.dpNgayTraLyThuyet.Text)||
                string.IsNullOrEmpty(this.txtTienCoc.Text))
            {
                MessageBox.Show("Vui lòng kiểm tra lại các trường trên!");
                return;
            }
            try
            {
                //Thêm dữ liệu vào bảng phiếu mượn
                PhieuMuonDTO phieuMuonDTO = new PhieuMuonDTO() {
                    IdDocGia = (int)this.cbDocGia.SelectedValue,
                    NgayMuon = this.dpNgayMuon.Text,
                    NgayTraLyThuyet = this.dpNgayTraLyThuyet.Text,
                    TienCoc = int.Parse(this.txtTienCoc.Text)

                };
                int idPhieuMuon = new PhieuMuonBUS().Insert(phieuMuonDTO);
                if (idPhieuMuon == -1)
                {
                    MessageBox.Show("Them phieu muon that bai!");
                }
                //Thêm dữ liệu vào bảng phiếu mượn chi tiết
                foreach (DataRow dtRow in tableBooks.Rows)
                {
                    PhieuMuonChiTietDTO phieuMuonChiTiet = new PhieuMuonChiTietDTO() {
                        IdPhieuMuon = idPhieuMuon,
                        IdSach = int.Parse(dtRow["Mã sách"].ToString()),
                        SoLuongMuon = int.Parse(dtRow["Số lượng"].ToString())
                    };
                    new PhieuMuonChiTietBUS().Insert(phieuMuonChiTiet);
                }
                MessageBox.Show("Xuất phiếu mượn thành công!", "Thông tin", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi!\n" + ex.Message);
            }
        }

        /// <summary>
        /// Xử lý chỉ cho phép nhập số
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtTienCoc_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Xử lý chọn đọc giả
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbDocGia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.txtTenDocGia.Text = this.tableDocGia.Rows[this.cbDocGia.SelectedIndex]["TenDocGia"].ToString();
            this.txtCmnd.Text = this.tableDocGia.Rows[this.cbDocGia.SelectedIndex]["Cmnd"].ToString();
            this.txtDiaChi.Text = this.tableDocGia.Rows[this.cbDocGia.SelectedIndex]["DiaChi"].ToString();
        }

        /// <summary>
        /// Xử lý xóa sách mượn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnXoaSach_Click(object sender, RoutedEventArgs e)
        {
            if (this.currIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đối tượng cần xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var confirm = MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    this.tableBooks.Rows.Remove(this.tableBooks.Rows[this.currIndex]);
                    MessageBox.Show("Đã xóa!");
                    LoadData();
                    int tinhTong = tinhTongSoLuong();
                    this.txtTongSoLuong.Text = tinhTong.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi!\n" + ex.Message);
                }
            }

        }

        /// <summary>
        /// Xử lý thêm sách mượn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnThemSach_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new DialogChooseBook();

            var result = dialog.ShowDialog();
            if (result == true)
            {
                int id = dialog.idSach;
                int soLuong = dialog.soLuong;
                DataRow dr = tableBooks.NewRow();
                dr["Mã sách"] = dialog.idSach;
                dr["Tên sách"] = dialog.tenSach;
                dr["Số lượng"] = dialog.soLuong;
                this.tableBooks.Rows.Add(dr);
                LoadData();
            }
            int tinhTong = tinhTongSoLuong();
            this.txtTongSoLuong.Text = tinhTong.ToString();
        }

        /// <summary>
        /// Xử lý xác nhận khi người dùng đóng cửa sổ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Lấy giá trị tại ô click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgSachMuon_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgSachMuon.Items.IndexOf(this.dgSachMuon.CurrentItem) >= 0)
            {
                this.currIndex = this.dgSachMuon.Items.IndexOf(this.dgSachMuon.CurrentItem);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Tải lại dữ liệu lên grid
        /// </summary>
        private void LoadData()
        {
            this.dgSachMuon.ItemsSource = tableBooks.DefaultView;
        }

        /// <summary>
        /// Tính tổng số lượng sách đọc giả mượn
        /// </summary>
        /// <returns></returns>
        private int tinhTongSoLuong()
        {
            int s = 0;
            foreach (DataRow dtRow in tableBooks.Rows)
            {
                s += int.Parse(dtRow["Số lượng"].ToString());
            }
            return s;
        }
        #endregion


    }
}
