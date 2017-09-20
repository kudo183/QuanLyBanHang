using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rKhoHangView : BaseView<rKhoHangDto, rKhoHangDataModel>
    {
        partial void InitUIPartial();

        public rKhoHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
