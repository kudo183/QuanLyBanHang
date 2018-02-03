using Client.DataModel;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Linq;

namespace Client.ViewModel
{
    public partial class tChiPhiViewModel : BaseViewModel<tChiPhiDto, tChiPhiDataModel>
    {
        partial void AfterLoadPartial()
        {
            Msg = string.Format("Tong so tien: {0:N0}", Entities.Sum(p => p.SoTien));
        }
    }
}
