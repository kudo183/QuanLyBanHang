using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rKhachHangChanhView : BaseView<rKhachHangChanhDto, rKhachHangChanhDataModel>
    {
        partial void InitUIPartial();

        public rKhachHangChanhView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
