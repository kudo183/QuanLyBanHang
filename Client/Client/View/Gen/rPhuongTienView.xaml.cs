using huypq.SmtWpfClient.Abstraction;
using Shared;
using Client.DataModel;

namespace Client.View
{
    public partial class rPhuongTienView : BaseView<rPhuongTienDto, rPhuongTienDataModel>
    {
        partial void InitUIPartial();

        public rPhuongTienView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
