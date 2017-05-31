using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tChuyenKhoView : BaseView<tChuyenKhoDto>
    {
        partial void InitUIPartial();

        public tChuyenKhoView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
