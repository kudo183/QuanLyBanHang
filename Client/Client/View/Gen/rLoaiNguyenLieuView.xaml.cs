using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rLoaiNguyenLieuView : BaseView<rLoaiNguyenLieuDto>
    {
        partial void InitUIPartial();

        public rLoaiNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
