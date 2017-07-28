using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClient.View;
using huypq.SmtWpfClient.ViewModel;
using System.Windows;
using Client.View.Smt;
using System.Windows.Controls;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IDataService _dataService;
        LoginViewModel _loginViewModel;

        public MainWindow()
        {
            Init();

            InitializeComponent();

            _loginViewModel = loginView.DataContext as LoginViewModel;

#if DEBUG
            _loginViewModel.IsLoggedIn = true;
            _loginViewModel.IsTenant = true;
#else
            _loginViewModel.Email = SettingsWrapper.Instance.User;
            _loginViewModel.TenantName = SettingsWrapper.Instance.Tenant;
#endif

            _loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;
        }

        private void LoginViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(LoginViewModel.TenantName):
                    {
                        SettingsWrapper.Instance.Tenant = _loginViewModel.TenantName;
                    }
                    break;
                case nameof(LoginViewModel.Email):
                    {
                        SettingsWrapper.Instance.User = _loginViewModel.Email;
                    }
                    break;
            }
        }

        private void Init()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes();
            ServiceLocator.AddTypeMapping(typeof(IViewModelFactory), typeof(ViewModelFactory), true, new ViewModelFactory.Options()
            {
                ViewModelNamespace = "Client.ViewModel",
                ViewModelAssembly = System.Reflection.Assembly.GetExecutingAssembly()
            });

            ServiceLocator.AddTypeMapping(typeof(IDataService), typeof(ProtobufDataService), true, new ProtobufDataService.Options()
            {
#if DEBUG
                RootUri = "http://localhost:64406",
                Token = "CfDJ8J0Vem16TkFEi6NUK4o55AoAW9xUGy9ZFcoiW1dRgPuBmXIRdkeIyy4Mc60kE5-_2nAmHzcS1w9oIvTVi7k5DKwuS5zKEgf3qBJFtOvk24heIN0PcXBDpvxMf7GBcTEKkvv8zoiL9MBvArmHike0-mAC7ZCEIFhYVlCI3mU3o-Po",
#else
                RootUri = SettingsWrapper.Instance.Server
#endif
            });

            _dataService = ServiceLocator.Get<IDataService>();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            (loginView.DataContext as LoginViewModel).Logout();
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new ChangePasswordWindow();
            w.ShowDialog();
        }

        private void ManageUserButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new Window()
            {
                Content = new ManageUserView()
            };
            w.Show();
        }

        private void AllViewButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new Window()
            {
                Content = new AllView()
            };
            w.Show();
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            var button = (e.OriginalSource as Button);
            if (button == null)
            {
                return;
            }

            var viewType = System.Type.GetType("Client.View." + button.Tag);
            if (viewType == null)
            {
                viewType = System.Type.GetType("Client.View.Report." + button.Tag);
            }

            var w = new Window()
            {
                Title = button.Content.ToString(),
                WindowState = WindowState.Maximized,
                Content = System.Activator.CreateInstance(viewType)
            };
            w.Show();
        }
    }
}
