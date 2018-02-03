using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tToaHangView : BaseView<tToaHangDto, tToaHangDataModel>
    {
        partial void InitUIPartial();

        public tToaHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
