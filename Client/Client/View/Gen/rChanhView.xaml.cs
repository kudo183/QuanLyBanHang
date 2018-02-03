using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rChanhView : BaseView<rChanhDto, rChanhDataModel>
    {
        partial void InitUIPartial();

        public rChanhView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
