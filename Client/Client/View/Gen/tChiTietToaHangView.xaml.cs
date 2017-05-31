using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tChiTietToaHangView : BaseView<tChiTietToaHangDto>
    {
        partial void InitUIPartial();

        public tChiTietToaHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
