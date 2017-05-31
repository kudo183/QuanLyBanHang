using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tTonKhoView : BaseView<tTonKhoDto>
    {
        partial void InitUIPartial();

        public tTonKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
