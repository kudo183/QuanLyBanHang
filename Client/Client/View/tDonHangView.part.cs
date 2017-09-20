using Client.DataModel;
using Client.ViewModel;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Windows.Controls;

namespace Client.View
{
    public partial class tDonHangView : BaseView<tDonHangDto, tDonHangDataModel>
    {
        partial void InitUIPartial()
        {
            var btnPrintRemain = new Button()
            {
                Content = "In",
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                Width = 75,
                Margin = new System.Windows.Thickness(5)
            };
            btnPrintRemain.SetBinding(Button.CommandProperty, nameof(tDonHangViewModel.PrintRemainCommand));
            GridView.CustomMenuItems.Add(btnPrintRemain);

            var btnPrintAll = new Button()
            {
                Content = "In tất cả",
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                Width = 75,
                Margin = new System.Windows.Thickness(5)
            };
            btnPrintAll.SetBinding(Button.CommandProperty, nameof(tDonHangViewModel.PrintAllCommand));
            GridView.CustomMenuItems.Add(btnPrintAll);

            var btnTonKho = new Button()
            {
                Content = "Tồn kho",
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                Width = 75,
                Margin = new System.Windows.Thickness(5)
            };
            btnTonKho.SetBinding(Button.CommandProperty, nameof(tDonHangViewModel.TonKhoCommand));
            GridView.CustomMenuItems.Add(btnTonKho);
        }
    }
}
