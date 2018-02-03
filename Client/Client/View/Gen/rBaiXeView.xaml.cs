using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rBaiXeView : BaseView<rBaiXeDto, rBaiXeDataModel>
    {
        partial void InitUIPartial();

        public rBaiXeView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
