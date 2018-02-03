using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rNguyenLieuView : BaseView<rNguyenLieuDto, rNguyenLieuDataModel>
    {
        partial void InitUIPartial();

        public rNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
