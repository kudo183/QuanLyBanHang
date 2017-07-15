using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClient.View;
using huypq.SmtWpfClient.ViewModel;
using System.Windows;
using Client.View.Smt;

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
                Token = "CfDJ8J0Vem16TkFEi6NUK4o55Aq1oLWtnzQB4QMkwpV1b8cI-ZmU-f6ma5EiIfR-caLTHzOk8369KjfDJjLIFUaN1ZdcX6d-FhWQ3D4sNMLaecazjnM4NsUlGU6oVeid9zomwZwakM8eORcqo1wqwigrE0AQLxNVvWTJWMg7fElpfqKW"
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
    }
}
