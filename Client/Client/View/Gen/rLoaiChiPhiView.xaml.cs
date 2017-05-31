using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rLoaiChiPhiView : BaseView<rLoaiChiPhiDto>
    {
        partial void InitUIPartial();

        public rLoaiChiPhiView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
