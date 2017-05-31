using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tNhanTienKhachHangView : BaseView<tNhanTienKhachHangDto>
    {
        partial void InitUIPartial();

        public tNhanTienKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
