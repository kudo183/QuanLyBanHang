using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tCongNoKhachHangView : BaseView<tCongNoKhachHangDto>
    {
        partial void InitUIPartial();

        public tCongNoKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
