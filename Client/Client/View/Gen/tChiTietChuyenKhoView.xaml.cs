using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tChiTietChuyenKhoView : BaseView<tChiTietChuyenKhoDto>
    {
        partial void InitUIPartial();

        public tChiTietChuyenKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
