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

        public MainWindow()
        {
            Init();

            InitializeComponent();

#if DEBUG
            (loginView.DataContext as LoginViewModel).IsLoggedIn = true;
            (loginView.DataContext as LoginViewModel).IsTenant = true;
#endif
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
                RootUri = SettingsWrapper.Instance.Server,
#if DEBUG
                Token = "CfDJ8J0Vem16TkFEi6NUK4o55AqtojUMnMK-uzygFJrEuySYvZZh37c8xK8vM4JXKdilsQtxYw6IKwfTx2mOKdkT6Pppn_y6z2Kr1oi2xezvRYPyEN7zDM3uBCCb8TBc_si8hC5oKakNLpvuGVr45lTxcILSy7tlVmsZlh9zLcjFtb2X"
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
