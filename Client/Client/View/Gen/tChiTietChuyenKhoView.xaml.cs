using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tChiTietChuyenKhoView : BaseView<tChiTietChuyenKhoDto, tChiTietChuyenKhoDataModel>
    {
        partial void InitUIPartial();

        public tChiTietChuyenKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
