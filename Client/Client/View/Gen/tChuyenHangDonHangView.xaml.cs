using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tChuyenHangDonHangView : BaseView<tChuyenHangDonHangDto, tChuyenHangDonHangDataModel>
    {
        partial void InitUIPartial();

        public tChuyenHangDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
