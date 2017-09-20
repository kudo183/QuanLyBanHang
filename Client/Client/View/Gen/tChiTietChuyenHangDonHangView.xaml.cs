using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tChiTietChuyenHangDonHangView : BaseView<tChiTietChuyenHangDonHangDto, tChiTietChuyenHangDonHangDataModel>
    {
        partial void InitUIPartial();

        public tChiTietChuyenHangDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
