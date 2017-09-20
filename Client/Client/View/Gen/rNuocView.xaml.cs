using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rNuocView : BaseView<rNuocDto, rNuocDataModel>
    {
        partial void InitUIPartial();

        public rNuocView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
