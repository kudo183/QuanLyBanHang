using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rNhanVienView : BaseView<rNhanVienDto>
    {
        partial void InitUIPartial();

        public rNhanVienView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
