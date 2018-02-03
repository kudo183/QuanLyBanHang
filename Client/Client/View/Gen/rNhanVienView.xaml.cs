using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rNhanVienView : BaseView<rNhanVienDto, rNhanVienDataModel>
    {
        partial void InitUIPartial();

        public rNhanVienView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
