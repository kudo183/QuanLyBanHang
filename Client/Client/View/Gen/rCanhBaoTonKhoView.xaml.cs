using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rCanhBaoTonKhoView : BaseView<rCanhBaoTonKhoDto, rCanhBaoTonKhoDataModel>
    {
        partial void InitUIPartial();

        public rCanhBaoTonKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
