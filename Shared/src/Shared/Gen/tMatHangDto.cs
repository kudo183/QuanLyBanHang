using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class tMatHangDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        int oMaLoai;
        string oTenMatHang;
        int oSoKy;
        int oSoMet;
        string oTenMatHangDayDu;
        string oTenMatHangIn;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma;
        int _MaLoai;
        string _TenMatHang;
        int _SoKy;
        int _SoMet;
        string _TenMatHangDayDu;
        string _TenMatHangIn;
        int _TenantID;
        long _CreateTime;
        long _LastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaLoai { get { return _MaLoai; } set { _MaLoai = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public string TenMatHang { get { return _TenMatHang; } set { _TenMatHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int SoKy { get { return _SoKy; } set { _SoKy = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int SoMet { get { return _SoMet; } set { _SoMet = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public string TenMatHangDayDu { get { return _TenMatHangDayDu; } set { _TenMatHangDayDu = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(7)]
        public string TenMatHangIn { get { return _TenMatHangIn; } set { _TenMatHangIn = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(8)]
        public int TenantID { get { return _TenantID; } set { _TenantID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(9)]
        public long CreateTime { get { return _CreateTime; } set { _CreateTime = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(10)]
        public long LastUpdateTime { get { return _LastUpdateTime; } set { _LastUpdateTime = value; OnPropertyChanged(); } }

        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }
        
        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oMaLoai = MaLoai;
            oTenMatHang = TenMatHang;
            oSoKy = SoKy;
            oSoMet = SoMet;
            oTenMatHangDayDu = TenMatHangDayDu;
            oTenMatHangIn = TenMatHangIn;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as tMatHangDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaLoai = dto.MaLoai;
            TenMatHang = dto.TenMatHang;
            SoKy = dto.SoKy;
            SoMet = dto.SoMet;
            TenMatHangDayDu = dto.TenMatHangDayDu;
            TenMatHangIn = dto.TenMatHangIn;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma)||
            (oMaLoai != MaLoai)||
            (oTenMatHang != TenMatHang)||
            (oSoKy != SoKy)||
            (oSoMet != SoMet)||
            (oTenMatHangDayDu != TenMatHangDayDu)||
            (oTenMatHangIn != TenMatHangIn)||
            (oTenantID != TenantID)||
            (oCreateTime != CreateTime)||
            (oLastUpdateTime != LastUpdateTime);
        }

        public rLoaiHangDto MaLoairLoaiHangDto { get; set; }

        object _MaLoaiDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaLoaiDataSource { get { return _MaLoaiDataSource; } set { _MaLoaiDataSource = value; OnPropertyChanged(); } }

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
