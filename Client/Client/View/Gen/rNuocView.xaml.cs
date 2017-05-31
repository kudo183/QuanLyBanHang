using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rNuocView : BaseView<rNuocDto>
    {
        partial void InitUIPartial();

        public rNuocView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
