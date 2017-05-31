using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tNhapNguyenLieuView : BaseView<tNhapNguyenLieuDto>
    {
        partial void InitUIPartial();

        public tNhapNguyenLieuView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
