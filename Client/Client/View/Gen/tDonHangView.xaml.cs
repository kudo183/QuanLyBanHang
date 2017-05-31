using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tDonHangView : BaseView<tDonHangDto>
    {
        partial void InitUIPartial();

        public tDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
