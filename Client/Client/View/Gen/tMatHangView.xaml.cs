using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tMatHangView : BaseView<tMatHangDto, tMatHangDataModel>
    {
        partial void InitUIPartial();

        public tMatHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
