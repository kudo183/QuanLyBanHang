using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tChiTietNhapHangView : BaseView<tChiTietNhapHangDto>
    {
        partial void InitUIPartial();

        public tChiTietNhapHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
