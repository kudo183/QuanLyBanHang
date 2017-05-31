using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tChiPhiView : BaseView<tChiPhiDto>
    {
        partial void InitUIPartial();

        public tChiPhiView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
