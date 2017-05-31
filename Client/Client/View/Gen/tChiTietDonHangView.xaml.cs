using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tChiTietDonHangView : BaseView<tChiTietDonHangDto>
    {
        partial void InitUIPartial();

        public tChiTietDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
