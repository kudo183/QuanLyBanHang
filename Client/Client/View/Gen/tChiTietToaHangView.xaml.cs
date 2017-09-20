using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tChiTietToaHangView : BaseView<tChiTietToaHangDto, tChiTietToaHangDataModel>
    {
        partial void InitUIPartial();

        public tChiTietToaHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
