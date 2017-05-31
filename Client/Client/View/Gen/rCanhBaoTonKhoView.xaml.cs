using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rCanhBaoTonKhoView : BaseView<rCanhBaoTonKhoDto>
    {
        partial void InitUIPartial();

        public rCanhBaoTonKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
