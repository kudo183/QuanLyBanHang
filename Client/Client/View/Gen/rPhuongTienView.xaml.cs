using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rPhuongTienView : BaseView<rPhuongTienDto>
    {
        partial void InitUIPartial();

        public rPhuongTienView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
