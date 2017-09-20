using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tChiTietDonHangView : BaseView<tChiTietDonHangDto, tChiTietDonHangDataModel>
    {
        partial void InitUIPartial();

        public tChiTietDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
