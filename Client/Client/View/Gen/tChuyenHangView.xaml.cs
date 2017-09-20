using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tChuyenHangView : BaseView<tChuyenHangDto, tChuyenHangDataModel>
    {
        partial void InitUIPartial();

        public tChuyenHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
