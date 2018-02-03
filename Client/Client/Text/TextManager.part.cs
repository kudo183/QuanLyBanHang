namespace Client
{
    public static partial class TextManager
    {
        public static string Button_Ok { get { return GetText(); } }
        public static string LoginWindow_CannotConnect { get { return GetText(); } }
        public static string LoginWindow_LoginFailed { get { return GetText(); } }
        public static string LoginWindow_Title { get { return GetText(); } }
        public static string LoginWindow_TxtPassword { get { return GetText(); } }
        public static string LoginWindow_TxtUser { get { return GetText(); } }
        public static string LoginWindow_TxtGroupList { get { return GetText(); } }
        public static string LoginWindow_BtnLogin { get { return GetText(); } }

        public static string tToaHang_ThanhTien { get { return GetText(); } }
        public static string tChiTietToaHang_ThanhTien { get { return GetText(); } }
        public static string tChuyenKho_TongSoLuong { get { return GetText(); } }
        public static string tNhapHang_TongSoLuong { get { return GetText(); } }
        public static string tChiTietDonHang_TonKho { get { return GetText(); } }

        static partial void InitDefaultLanguageDataPartial()
        {
            _dic.Add("Button_Ok", "OK");
            _dic.Add("LoginWindow_CannotConnect", "Không kết nối được máy chủ.");
            _dic.Add("LoginWindow_LoginFailed", "Sai Tên đăng nhập hoặc Mã đăng nhập.");
            _dic.Add("LoginWindow_Title", "Đăng Nhập");
            _dic.Add("LoginWindow_TxtPassword", "Mã đăng nhập:");
            _dic.Add("LoginWindow_TxtUser", "Tên đăng nhập:");
            _dic.Add("LoginWindow_TxtGroupList", "Tên tổ chức:");
            _dic.Add("LoginWindow_BtnLogin", "Đăng Nhập");

            _dic.Add(nameof(tToaHang_ThanhTien), "Thành Tiền");
            _dic.Add(nameof(tChiTietToaHang_ThanhTien), "Thành Tiền");
            _dic.Add(nameof(tChuyenKho_TongSoLuong), "Tổng số lượng");
            _dic.Add(nameof(tNhapHang_TongSoLuong), "Tổng số lượng");
            _dic.Add(nameof(tChiTietDonHang_TonKho), "Tồn kho");
        }
    }
}
