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

namespace Bai06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtGiaTri.Focus();
        }

        private void BtnNhap_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(txtGiaTri.Text);
                lbxGiaTri.Items.Add(i);
                txtGiaTri.Clear();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            txtGiaTri.Focus();
        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            if (lbxGiaTri.SelectedItems.Count > 0)
            {
                int i = lbxGiaTri.SelectedIndex;
                try
                {
                    int num = Convert.ToInt32(txtGiaTri.Text);
                    lbxGiaTri.Items[i] = num;
                    txtGiaTri.Clear();
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                txtGiaTri.Focus();
            }
            else
            {
                MessageBox.Show("Chưa chọn phần tử nào để sửa!");
            }
        }

        private void LbxGiaTri_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxGiaTri.SelectedItems.Count > 0)
            {
                txtGiaTri.Text = lbxGiaTri.SelectedItems[0].ToString();
            }
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (lbxGiaTri.SelectedItems.Count > 0)
            {
                MessageBoxResult rslt = MessageBox.Show("Bạn có muốn xóa phần tử đang chọn?", "Thông Báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rslt == MessageBoxResult.Yes)
                {
                    lbxGiaTri.Items.RemoveAt(lbxGiaTri.SelectedIndex);
                    txtGiaTri.Clear();
                }            
            }
            else
            {
                MessageBox.Show("Chưa chọn phần tử nào để xóa!");
            }
        }
    }
}
