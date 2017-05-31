using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tNhapHangView : BaseView<tNhapHangDto>
    {
        partial void InitUIPartial();

        public tNhapHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
