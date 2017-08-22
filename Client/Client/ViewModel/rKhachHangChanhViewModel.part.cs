using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.ViewModel
{
    public partial class rKhachHangChanhViewModel : BaseViewModel<rKhachHangChanhDto>
    {
        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<rBaiXeDto>.Instance.LoadOrUpdate();
        }

        protected override void AfterLoad()
        {
            foreach (var dto in Entities)
            {
                dto.MaChanhNavigation = ReferenceDataManager<rChanhDto>.Instance.GetByID(dto.MaChanh);
                dto.MaChanhNavigation.MaBaiXeNavigation = ReferenceDataManager<rBaiXeDto>.Instance.GetByID(dto.MaChanhNavigation.MaBaiXe);
            }
        }
    }
}
