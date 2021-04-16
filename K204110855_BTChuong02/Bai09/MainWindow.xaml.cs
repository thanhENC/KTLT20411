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

namespace Bai09
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtTenSV.Focus();
        }

        private void BtnNhap_Click(object sender, RoutedEventArgs e)
        {
            if (txtTenSV.Text != "")
            {
                lbxLopA.Items.Add(txtTenSV.Text);
            }
            else
            {
                MessageBox.Show("Chưa nhập tên SV", "Thông Báo");
            }
            txtTenSV.Clear();
            txtTenSV.Focus();
        }

        private void BtnAtoB_Click(object sender, RoutedEventArgs e)
        {
            if (lbxLopA.SelectedItems.Count > 0)
            {
                lbxLopB.Items.Add(lbxLopA.SelectedItems[0]);
                lbxLopA.Items.RemoveAt(lbxLopA.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Chưa chọn SV lớp A", "Thông Báo");
            }
        }

        private void BtnAllAtoB_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < lbxLopA.Items.Count; i++)
            {
                lbxLopB.Items.Add(lbxLopA.Items[i]);
            }
            lbxLopA.Items.Clear();
        }

        private void BtnBtoA_Click(object sender, RoutedEventArgs e)
        {
            if (lbxLopB.SelectedItems.Count > 0)
            {
                lbxLopA.Items.Add(lbxLopB.SelectedItems[0]);
                lbxLopB.Items.RemoveAt(lbxLopB.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Chưa chọn SV lớp B", "Thông Báo");
            }
        }

        private void BtnAllBtoA_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < lbxLopB.Items.Count; i++)
            {
                lbxLopA.Items.Add(lbxLopB.Items[i]);
            }
            lbxLopB.Items.Clear();
        }

        private void BtnXoaLopA_Click(object sender, RoutedEventArgs e)
        {
            lbxLopA.Items.Clear();
        }

        private void BtnXoaLopB_Click(object sender, RoutedEventArgs e)
        {
            lbxLopB.Items.Clear();
        }

        private void BtnKetThuc_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rslt = MessageBox.Show("Bạn có muốn Kết Thúc chương trình?", "Thông Báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (rslt == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
