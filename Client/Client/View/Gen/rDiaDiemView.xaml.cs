using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rDiaDiemView : BaseView<rDiaDiemDto, rDiaDiemDataModel>
    {
        partial void InitUIPartial();

        public rDiaDiemView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
