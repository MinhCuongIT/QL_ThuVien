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
    /// Interaction logic for ThongKeWindow.xaml
    /// </summary>
    public partial class ThongKeWindow : Window
    {
        #region Properties
        private ThongKeBUS thongKeBUS = new ThongKeBUS();
        #endregion
        public ThongKeWindow()
        {
            InitializeComponent();
        }

        private void BtnThongKe_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        /// <summary>
        /// Xử lý tải dữ liệu cần sử dụng khi màn hình được tải lên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime nowTime = DateTime.Now;
            int[] month = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if ((nowTime.Year % 4 == 0 && nowTime.Year % 100 != 0) || nowTime.Year % 400 == 0)
            {
                month[1]++;
            }
            this.dpFromDate.Text = $"{nowTime.Year}-{nowTime.Month}-{1}";
            this.dpToDate.Text = $"{nowTime.Year}-{nowTime.Month}-{month[nowTime.Month - 1]}";
            LoadData();
        }

        #region Methods
        private void LoadData()
        {
            try
            {
                //Set dữ liệu cho biểu đồ bánh
                List<KeyValuePair<string, int>> valueListLoaiSach = new List<KeyValuePair<string, int>>();
                DataTable tableLoaiSach = this.thongKeBUS.GetLoaiSachWithDetails();
                foreach (DataRow row in tableLoaiSach.Rows)
                {
                    valueListLoaiSach.Add(new KeyValuePair<string, int>(row["TenLoaiSach"].ToString(), (int)row["Tong"]));
                }
                this.pieChart.DataContext = valueListLoaiSach;
                //Set dữ liệu cho biểu đồ cột
                List<KeyValuePair<string, int>> valueListLoaiSachOfMonth = new List<KeyValuePair<string, int>>();
                DataTable tableLoaiSachOfMonth = this.thongKeBUS.GetLoaiSachWithDate(this.dpFromDate.Text, this.dpToDate.Text);
                int tongSachChoMuon = 0;
                foreach (DataRow row in tableLoaiSachOfMonth.Rows)
                {
                    valueListLoaiSachOfMonth.Add(new KeyValuePair<string, int>(row["TenLoaiSach"].ToString(), (int)row["Tong"]));
                    tongSachChoMuon += (int)row["Tong"];
                }
                this.columnChart.DataContext = valueListLoaiSachOfMonth;
                this.txtTongSoSachChoMuon.Text = tongSachChoMuon.ToString();

                this.txtTongSoDocGia.Text = this.thongKeBUS.GetTongSoLuongDocGia(this.dpFromDate.Text, this.dpToDate.Text).ToString();
                this.txtTongDGDungHan.Text = this.thongKeBUS.GetDocGiaDungHan(this.dpFromDate.Text, this.dpToDate.Text).ToString();
                this.txtTongDGTreHan.Text = this.thongKeBUS.GetDocGiaTreHan(this.dpFromDate.Text, this.dpToDate.Text).ToString();
                this.txtTongSoSachTrongKho.Text = this.thongKeBUS.GetTongSoSachTrongKho().ToString();
                this.txtTongSoSachConLai.Text = this.thongKeBUS.GetTongSoSachConLai().ToString();

                //Set dữ liệu cho bảng Top 10
                this.dgBXH.ItemsSource = this.thongKeBUS.GetTop10DocGia(this.dpFromDate.Text, this.dpToDate.Text).DefaultView;
                this.dgBXH.Columns[0].Header = "Tên";
                this.dgBXH.Columns[1].Header = "Địa chỉ";
                this.dgBXH.Columns[2].Header = "Ngày mượn";
                this.dgBXH.Columns[3].Header = "Tổng mượn";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong quá trình thống kê!\n" + ex.Message);
            }
        }
        #endregion
    }
}
