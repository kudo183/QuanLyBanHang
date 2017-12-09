using Client.ViewModel;
using System.Windows.Controls;

namespace Client.View
{
    public partial class tTonKhoView
    {
        partial void InitUIPartial()
        {
            var btnTonHangNhap = new Button()
            {
                Content = "Copy Ton Hang Nhap",
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                Margin = new System.Windows.Thickness(5)
            };
            btnTonHangNhap.Click += BtnTonHangNhap_Click;
            GridView.CustomMenuItems.Add(btnTonHangNhap);

            var btnTonHangNha = new Button()
            {
                Content = "Copy Ton Hang Nha",
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                Margin = new System.Windows.Thickness(5)
            };
            btnTonHangNha.Click += BtnTonHangNha_Click;
            GridView.CustomMenuItems.Add(btnTonHangNha);
        }

        private void BtnTonHangNhap_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = ViewModel as tTonKhoViewModel;
            vm.CopyTonKhoToClipboard(false);
        }

        private void BtnTonHangNha_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = ViewModel as tTonKhoViewModel;
            vm.CopyTonKhoToClipboard(true);
        }
    }
}
