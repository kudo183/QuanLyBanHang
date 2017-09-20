using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tChiPhiView : BaseView<tChiPhiDto, tChiPhiDataModel>
    {
        partial void InitUIPartial();

        public tChiPhiView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
