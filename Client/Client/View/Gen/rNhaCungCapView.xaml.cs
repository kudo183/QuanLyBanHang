using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rNhaCungCapView : BaseView<rNhaCungCapDto, rNhaCungCapDataModel>
    {
        partial void InitUIPartial();

        public rNhaCungCapView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
