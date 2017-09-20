using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tTonKhoView : BaseView<tTonKhoDto, tTonKhoDataModel>
    {
        partial void InitUIPartial();

        public tTonKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
