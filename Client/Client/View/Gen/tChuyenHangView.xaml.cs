using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tChuyenHangView : BaseView<tChuyenHangDto>
    {
        partial void InitUIPartial();

        public tChuyenHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
