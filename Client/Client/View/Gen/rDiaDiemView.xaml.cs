using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class rDiaDiemView : BaseView<rDiaDiemDto>
    {
        partial void InitUIPartial();

        public rDiaDiemView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
