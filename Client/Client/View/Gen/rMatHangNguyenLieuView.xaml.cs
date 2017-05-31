using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rMatHangNguyenLieuView : BaseView<rMatHangNguyenLieuDto>
    {
        partial void InitUIPartial();

        public rMatHangNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
