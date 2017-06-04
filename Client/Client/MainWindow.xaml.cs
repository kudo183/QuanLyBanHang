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
                //RootUri = "http://localhost:5000",
                RootUri = "http://luoithepvinhphat.com:5000",
#if DEBUG
                Token = "CfDJ8J0CZcxInRhFvSirfZanTFyk8fHk5vjz-W15GWkoPkkskq56hc_BY703cjKiS6LtYAiM8Y3-5g0JHWSOpyO9T1osA622eK7ehoQNMyr0dPnVnrKR8qbsCltAZ-cMUJSoB_qqLcaojDswxMjh-TgmRHEhfZlk6NgvbU5Yr7yfM9jB"
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
