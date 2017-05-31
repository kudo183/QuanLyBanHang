using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tToaHangView : BaseView<tToaHangDto>
    {
        partial void InitUIPartial();

        public tToaHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
