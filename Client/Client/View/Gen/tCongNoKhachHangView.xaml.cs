using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tCongNoKhachHangView : BaseView<tCongNoKhachHangDto, tCongNoKhachHangDataModel>
    {
        partial void InitUIPartial();

        public tCongNoKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
