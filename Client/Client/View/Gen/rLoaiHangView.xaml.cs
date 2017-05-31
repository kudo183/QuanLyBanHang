using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rLoaiHangView : BaseView<rLoaiHangDto>
    {
        partial void InitUIPartial();

        public rLoaiHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
