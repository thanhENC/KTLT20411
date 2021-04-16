using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bai05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtTenHang.Focus();
        }

        int tongHoaDon = 0;
        long tongDoanhThu = 0;
        private void BtnTinh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int soLuong = Convert.ToInt32(txtSoLuong.Text);
                int donGia = Convert.ToInt32(txtDonGia.Text);
                long thanhTien = soLuong * donGia;
                txtThanhTien.Text = thanhTien + "(VNĐ)";
                tongHoaDon++;
                tongDoanhThu += thanhTien;
                btnTinh.IsEnabled = false;
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnTiep_Click(object sender, RoutedEventArgs e)
        {
         
            txtTenHang.Clear();
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtThanhTien.Clear();
            txtTenHang.Focus();
            btnTinh.IsEnabled = true;
        }

        private void BtnThongKe_Click(object sender, RoutedEventArgs e)
        {
            txtTongHoaDon.Text = tongHoaDon + "";
            txtTongDoanhThu.Text = tongDoanhThu + "";
        }

        private void BtnKetThuc_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rslt = MessageBox.Show("Bạn muốn Kết Thúc chương trình?", "Thông Báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (rslt == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
