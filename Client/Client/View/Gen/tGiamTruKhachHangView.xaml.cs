using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tGiamTruKhachHangView : BaseView<tGiamTruKhachHangDto>
    {
        partial void InitUIPartial();

        public tGiamTruKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
