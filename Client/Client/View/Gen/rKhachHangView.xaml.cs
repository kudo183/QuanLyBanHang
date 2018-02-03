using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rKhachHangView : BaseView<rKhachHangDto, rKhachHangDataModel>
    {
        partial void InitUIPartial();

        public rKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
