using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client
{
    public sealed class SettingsWrapper
    {
        private static Settings _instance;

        static SettingsWrapper()
        {
            _instance = new Settings();
            _instance.PropertyChanged += _instance_PropertyChanged;
        }

        public static Settings Instance
        {
            get { return _instance; }
        }

        private static string SettingsFileName = "settings.json";

        public static void Load()
        {
            if (System.IO.File.Exists(SettingsFileName))
            {
                var text = System.IO.File.ReadAllText(SettingsFileName);
                try
                {
                    _instance.Update(Newtonsoft.Json.JsonConvert.DeserializeObject<Settings>(text));
                }
                catch { }
            }
        }

        private static void _instance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Settings.tDonHang_MaKhoHangDefault):
                    {
                        Shared.tDonHangDto.DMaKhoHang = Instance.tDonHang_MaKhoHangDefault;
                    }
                    break;
                case nameof(Settings.tDonHang_MaKhachHangDefault):
                    {
                        Shared.tDonHangDto.DMaKhachHang = Instance.tDonHang_MaKhachHangDefault;
                    }
                    break;
            }
        }

        public static void Save()
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(_instance, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(SettingsFileName, output);
        }

        private SettingsWrapper() { }

        public class Settings : INotifyPropertyChanged
        {
            private string _server = "http://luoithepvinhphat.com";

            public string Server
            {
                get { return _server; }
                set
                {
                    if (_server == value)
                        return;

                    _server = value;
                    OnPropertyChanged();
                }
            }


            private string _tenant;

            public string Tenant
            {
                get { return _tenant; }
                set
                {
                    if (_tenant == value)
                        return;

                    _tenant = value;
                    OnPropertyChanged();
                }
            }

            private string _user;

            public string User
            {
                get { return _user; }
                set
                {
                    if (_user == value)
                        return;

                    _user = value;
                    OnPropertyChanged();
                }
            }

            private int _tDonHang_MaKhoHangDefault;

            public int tDonHang_MaKhoHangDefault
            {
                get { return _tDonHang_MaKhoHangDefault; }
                set
                {
                    if (_tDonHang_MaKhoHangDefault == value)
                        return;

                    _tDonHang_MaKhoHangDefault = value;
                    OnPropertyChanged();
                }
            }

            private int _tDonHang_MaKhachHangDefault;

            public int tDonHang_MaKhachHangDefault
            {
                get { return _tDonHang_MaKhachHangDefault; }
                set
                {
                    if (_tDonHang_MaKhachHangDefault == value)
                        return;

                    _tDonHang_MaKhachHangDefault = value;
                    OnPropertyChanged();
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public void Update(Settings settings)
            {
                Server = settings.Server;
                Tenant = settings.Tenant;
                User = settings.User;
                tDonHang_MaKhoHangDefault = settings.tDonHang_MaKhoHangDefault;
                tDonHang_MaKhachHangDefault = settings.tDonHang_MaKhachHangDefault;
            }
        }
    }
}
