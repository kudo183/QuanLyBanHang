using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tGiamTruKhachHangView : BaseView<tGiamTruKhachHangDto, tGiamTruKhachHangDataModel>
    {
        partial void InitUIPartial();

        public tGiamTruKhachHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
