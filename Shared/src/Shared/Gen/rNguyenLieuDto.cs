using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class rNguyenLieuDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        int oMaLoaiNguyenLieu;
        int oDuongKinh;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma;
        int _MaLoaiNguyenLieu;
        int _DuongKinh;
        int _TenantID;
        long _CreateTime;
        long _LastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaLoaiNguyenLieu { get { return _MaLoaiNguyenLieu; } set { _MaLoaiNguyenLieu = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int DuongKinh { get { return _DuongKinh; } set { _DuongKinh = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int TenantID { get { return _TenantID; } set { _TenantID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public long CreateTime { get { return _CreateTime; } set { _CreateTime = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public long LastUpdateTime { get { return _LastUpdateTime; } set { _LastUpdateTime = value; OnPropertyChanged(); } }

        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }
        
        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oMaLoaiNguyenLieu = MaLoaiNguyenLieu;
            oDuongKinh = DuongKinh;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as rNguyenLieuDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaLoaiNguyenLieu = dto.MaLoaiNguyenLieu;
            DuongKinh = dto.DuongKinh;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma)||
            (oMaLoaiNguyenLieu != MaLoaiNguyenLieu)||
            (oDuongKinh != DuongKinh)||
            (oTenantID != TenantID)||
            (oCreateTime != CreateTime)||
            (oLastUpdateTime != LastUpdateTime);
        }

        public rLoaiNguyenLieuDto MaLoaiNguyenLieurLoaiNguyenLieuDto { get; set; }

        object _MaLoaiNguyenLieuDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaLoaiNguyenLieuDataSource { get { return _MaLoaiNguyenLieuDataSource; } set { _MaLoaiNguyenLieuDataSource = value; OnPropertyChanged(); } }

        [Newtonsoft.Json.JsonIgnore]
        public int ID { get { return Ma; } set { Ma = value;} }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            RaiseDependentPropertyChanged(name);
        }

        partial void RaiseDependentPropertyChanged(string basePropertyName);
    }
}
