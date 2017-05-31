using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class ThamSoNgayView : BaseView<ThamSoNgayDto>
    {
        partial void InitUIPartial();

        public ThamSoNgayView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
