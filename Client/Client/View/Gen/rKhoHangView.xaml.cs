using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rKhoHangView : BaseView<rKhoHangDto>
    {
        partial void InitUIPartial();

        public rKhoHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
