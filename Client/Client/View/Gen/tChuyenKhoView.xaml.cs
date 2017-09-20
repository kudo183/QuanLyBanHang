using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tChuyenKhoView : BaseView<tChuyenKhoDto, tChuyenKhoDataModel>
    {
        partial void InitUIPartial();

        public tChuyenKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
