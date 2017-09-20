using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tDonHangView : BaseView<tDonHangDto, tDonHangDataModel>
    {
        partial void InitUIPartial();

        public tDonHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
