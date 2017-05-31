using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rNguyenLieuView : BaseView<rNguyenLieuDto>
    {
        partial void InitUIPartial();

        public rNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
