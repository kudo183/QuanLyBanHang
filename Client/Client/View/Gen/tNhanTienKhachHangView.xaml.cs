using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tNhanTienKhachHangView : BaseView<tNhanTienKhachHangDto, tNhanTienKhachHangDataModel>
    {
        partial void InitUIPartial();

        public tNhanTienKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
