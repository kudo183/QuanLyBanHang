using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class tNhapNguyenLieuView : BaseView<tNhapNguyenLieuDto, tNhapNguyenLieuDataModel>
    {
        partial void InitUIPartial();

        public tNhapNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
