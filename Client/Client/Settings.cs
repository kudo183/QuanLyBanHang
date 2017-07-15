using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client
{
    public sealed class SettingsWrapper
    {
        private static Settings _instance = new Settings();

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
                    _instance.PropertyChanged -= _instance_PropertyChanged;

                    _instance = Newtonsoft.Json.JsonConvert.DeserializeObject<Settings>(text);

                    _instance.PropertyChanged += _instance_PropertyChanged;
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

                    }
                    break;
                case nameof(Settings.tDonHang_MaKhachHangDefault):
                    {

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
            private string _server;

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
                get { return _tDonHang_MaKhoHangDefault; }
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
        }
    }
}
