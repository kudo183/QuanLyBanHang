using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tPhuThuKhachHangView : BaseView<tPhuThuKhachHangDto>
    {
        partial void InitUIPartial();

        public tPhuThuKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
