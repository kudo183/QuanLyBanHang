using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tChiTietChuyenHangDonHangView : BaseView<tChiTietChuyenHangDonHangDto>
    {
        partial void InitUIPartial();

        public tChiTietChuyenHangDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
