using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rChanhView : BaseView<rChanhDto>
    {
        partial void InitUIPartial();

        public rChanhView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
