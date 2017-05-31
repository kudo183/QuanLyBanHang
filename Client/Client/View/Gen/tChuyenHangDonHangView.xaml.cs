using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tChuyenHangDonHangView : BaseView<tChuyenHangDonHangDto>
    {
        partial void InitUIPartial();

        public tChuyenHangDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
