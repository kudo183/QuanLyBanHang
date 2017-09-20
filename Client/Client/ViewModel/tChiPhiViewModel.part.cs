using Client.DataModel;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Linq;

namespace Client.ViewModel
{
    public partial class tChiPhiViewModel : BaseViewModel<tChiPhiDto, tChiPhiDataModel>
    {
        protected override void AfterLoad()
        {
            Msg = string.Format("Tong so tien: {0:N0}", Entities.Sum(p => p.SoTien));
        }
    }
}
