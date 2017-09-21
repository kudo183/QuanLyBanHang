using Shared;

namespace Client.DataModel
{
    public partial class tToaHangDataModel
    {
        public int ThanhTien { get; set; }

        protected override void RaiseDependentPropertyChanged(string basePropertyName)
        {
            switch (basePropertyName)
            {
                case nameof(Ngay):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
                case nameof(MaKhachHang):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
            }
        }

        public override string DisplayText
        {
            get
            {
                if (MaKhachHangNavigation != null)
                {
                    return string.Format("{0}|{1}", Ngay.ToString("d"), MaKhachHangNavigation.DisplayText);
                }
                return ID.ToString();
            }
        }

        partial void FromDtoPartial(tToaHangDto dto)
        {
            ThanhTien = dto.ThanhTien;
        }
    }
}
