using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rKhachHangChanhView : BaseView<rKhachHangChanhDto>
    {
        partial void InitUIPartial();

        public rKhachHangChanhView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
