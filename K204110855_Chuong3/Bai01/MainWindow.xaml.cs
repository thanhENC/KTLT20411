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

namespace Bai01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtTen.Text;
            string gia = txtGia.Text;
            bool hangXachTay = (bool)cbxXachTay.IsChecked;
            string thue = "0";
            string giacuoi = "";
            if (hangXachTay == false)
            {
                thue = (0.1 * int.Parse(gia)).ToString();
                giacuoi = (0.85 * int.Parse(gia)).ToString();
            }
            HoaDon hd = new HoaDon() { Ma = ma, Ten = ten, Gia = gia, HangXachTay = hangXachTay, Thue = thue, GiaCuoi = giacuoi };
            lvHoaDon.Items.Add(hd);
            lvHoaDon.UnselectAll();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (lvHoaDon.SelectedIndex == -1)
            {
                MessageBox.Show("Phải chọn một hàng để xóa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult rslt = MessageBox.Show("Bạn chắc chắn muốn XÓA?", "Thông Báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (rslt == MessageBoxResult.Yes)
            {
                lvHoaDon.Items.RemoveAt(lvHoaDon.SelectedIndex);
            }    
        }

        private void lvHoaDon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvHoaDon.SelectedIndex == -1) 
                return;
            HoaDon hd = e.AddedItems[0] as HoaDon;
            txtMa.Text = hd.Ma;
            txtTen.Text = hd.Ten;
            txtGia.Text = hd.Gia;
            cbxXachTay.IsChecked = hd.HangXachTay;
        }

        private void mnuHeThongThoat_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rslt = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (rslt == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }    
        }
    }
}
