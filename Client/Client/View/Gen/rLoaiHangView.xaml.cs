using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rLoaiHangView : BaseView<rLoaiHangDto, rLoaiHangDataModel>
    {
        partial void InitUIPartial();

        public rLoaiHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
