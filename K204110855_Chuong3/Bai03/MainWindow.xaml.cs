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

namespace Bai03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtID.Focus();
            btnSave.IsEnabled = false;
        }

        //Khai báo 2 imageSource cho Male và Female để lát gán vào Img đc Binding bên listview
        //--------------
        public string maleSource = "pack://siteoforigin:,,,/Image/male.png";
        public string femaleSource = "pack://siteoforigin:,,,/Image/female.png";

        #region shutdown
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rslt = MessageBox.Show("Bạn có muốn Kết Thúc chương trình?", "Thông Báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (rslt == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        #endregion

        #region Form Drag Move
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lvManager.UnselectAll();
            this.DragMove();
        }
        #endregion


        //Xử lý Img trong SaveButton này nha
        //-------------
        #region Save item
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int order = lvManager.Items.Count + 1;
            string id = txtID.Text;
            string name = txtName.Text;

            //Này tui định nghĩa gender True thì là Male, False là Female
            bool gender = (bool)radMale.IsChecked;

            //Mặc định tui set imgSource là femaleSource để có gì người dùng quên tick Male/Female trong Gender nó sẽ k bị phát sinh lỗi
            //Sau đó kiểm tra gender đang true hay k để set maleSource (có thể viết gọn gender thôi chương trình tự hiểu là kiểm tra gender==true)
            //Đoạn code tường minh tui để trong comment dưới phần này
            Employee epl = new Employee { Order = order, ID = id, Name = name, Gender = gender, Img = femaleSource };
            if (gender)
            {
                epl.Img = maleSource;
            }

            //Đoạn code tường minh hơn
            //Employee epl;
            //if (gender==true)
            //{
            //    epl = new Employee { Order = order, ID = id, Name = name, Gender = gender, Img = maleSource };
            //}
            //else
            //{
            //    epl = new Employee { Order = order, ID = id, Name = name, Gender = gender, Img = femaleSource };
            //}

            lvManager.Items.Add(epl);
            lvManager.UnselectAll();
            Reset();
        }
        #endregion

        #region Remove item
        private void btnRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (lvManager.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn Employee để xóa!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int idx = lvManager.SelectedIndex;
            lvManager.Items.RemoveAt(idx);

            for ( ; idx < lvManager.Items.Count; idx++)
            {
                Employee epl = lvManager.Items[idx] as Employee;
                epl.Order--;           
            }
            lvManager.Items.Refresh();
        }
        #endregion

        #region SaveButton.IsEnabled
        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtID.Text != "" || txtName.Text != "")
            {
                btnSave.IsEnabled = true;
            }
            else
            {
                btnSave.IsEnabled = false;
            }
        }
        #endregion

        private void lvManager_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvManager.SelectedIndex == -1)
            {
                Reset();
                return;
            }
            
            Employee epl = lvManager.Items[lvManager.SelectedIndex] as Employee;
            txtID.Text = epl.ID;            
            txtName.Text = epl.Name;
            if (epl.Gender)
            {
                radMale.IsChecked = true;
            }
            else
            {
                radFemale.IsChecked = true;
            }            
        }

        private void Reset()
        {
            txtID.Clear();
            txtName.Clear();
            radFemale.IsChecked = false;
            radMale.IsChecked = false;
            txtID.Focus();
        }
    }
}
