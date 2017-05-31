using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rKhachHangView : BaseView<rKhachHangDto>
    {
        partial void InitUIPartial();

        public rKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
