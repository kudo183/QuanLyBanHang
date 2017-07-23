﻿namespace Shared
{
    public partial class rLoaiNguyenLieuDto : huypq.SmtShared.IDisplayText
    {
        partial void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(TenLoai))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public string DisplayText
        {
            get { return TenLoai; }
        }
    }
}