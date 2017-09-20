using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tChiTietNhapHangView : BaseView<tChiTietNhapHangDto, tChiTietNhapHangDataModel>
    {
        partial void InitUIPartial();

        public tChiTietNhapHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
