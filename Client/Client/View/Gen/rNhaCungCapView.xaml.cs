using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rNhaCungCapView : BaseView<rNhaCungCapDto>
    {
        partial void InitUIPartial();

        public rNhaCungCapView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
