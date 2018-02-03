using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rMatHangNguyenLieuView : BaseView<rMatHangNguyenLieuDto, rMatHangNguyenLieuDataModel>
    {
        partial void InitUIPartial();

        public rMatHangNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
