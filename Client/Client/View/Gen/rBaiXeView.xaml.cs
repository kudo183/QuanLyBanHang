using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rBaiXeView : BaseView<rBaiXeDto>
    {
        partial void InitUIPartial();

        public rBaiXeView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
