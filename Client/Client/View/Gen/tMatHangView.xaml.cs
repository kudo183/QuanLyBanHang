using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tMatHangView : BaseView<tMatHangDto>
    {
        partial void InitUIPartial();

        public tMatHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
