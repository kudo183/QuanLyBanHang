using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rLoaiChiPhiView : BaseView<rLoaiChiPhiDto, rLoaiChiPhiDataModel>
    {
        partial void InitUIPartial();

        public rLoaiChiPhiView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
