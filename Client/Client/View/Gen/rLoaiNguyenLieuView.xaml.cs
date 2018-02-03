using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rLoaiNguyenLieuView : BaseView<rLoaiNguyenLieuDto, rLoaiNguyenLieuDataModel>
    {
        partial void InitUIPartial();

        public rLoaiNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
