using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tNhapHangView : BaseView<tNhapHangDto, tNhapHangDataModel>
    {
        partial void InitUIPartial();

        public tNhapHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
