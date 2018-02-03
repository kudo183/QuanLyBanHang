using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class ThamSoNgayView : BaseView<ThamSoNgayDto, ThamSoNgayDataModel>
    {
        partial void InitUIPartial();

        public ThamSoNgayView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
