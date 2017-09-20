using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tPhuThuKhachHangView : BaseView<tPhuThuKhachHangDto, tPhuThuKhachHangDataModel>
    {
        partial void InitUIPartial();

        public tPhuThuKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
