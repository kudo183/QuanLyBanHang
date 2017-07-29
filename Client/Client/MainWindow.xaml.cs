using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClient.View;
using huypq.SmtWpfClient.ViewModel;
using System.Windows;
using Client.View.Smt;
using System.Windows.Controls;
using SimpleDataGrid.ViewModel;
using System.Collections.Generic;
using System.Linq;

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
            switch (e.PropertyName)
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
                //console app
                //RootUri = "http://localhost:64406",
                //Token = "CfDJ8J0Vem16TkFEi6NUK4o55AoAW9xUGy9ZFcoiW1dRgPuBmXIRdkeIyy4Mc60kE5-_2nAmHzcS1w9oIvTVi7k5DKwuS5zKEgf3qBJFtOvk24heIN0PcXBDpvxMf7GBcTEKkvv8zoiL9MBvArmHike0-mAC7ZCEIFhYVlCI3mU3o-Po",

                //IIS
                RootUri = "http://localhost",
                Token = "CfDJ8J0Vem16TkFEi6NUK4o55AqIEODDl3m6ghSor87FuJcPmx351Q90o_MOIMJgKVwO1oebGDK5mdlun5wMv5MWklGBOl6q7iSXcCQur53SLxHBVvi6FmdMMlVgqZCcUFwyoEKVF4lHdMvupUniH1yPz-CQgMwvAW16DDEx2wkeQgyv"
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
            allViewPopup.IsOpen = !allViewPopup.IsOpen;
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (e.OriginalSource as Button);
            if (button == null)
            {
                return;
            }

            if (sender is AllView)
            {
                allViewPopup.IsOpen = false;
            }

            var viewType = button.Tag as System.Type;

            var view = System.Activator.CreateInstance(viewType);

            var w = new Window()
            {
                Title = button.Content.ToString(),
                WindowState = WindowState.Maximized,
                Content = view
            };

            w.Loaded += W_Loaded;
            w.Closed += W_Closed;

            w.Show();
        }

        private List<IBaseView> GetViews(Window w)
        {
            if (w.Content is IBaseView iBaseView)
            {
                return new List<IBaseView>() { iBaseView };
            }

            if (w.Content is BaseComplexView baseComplexView)
            {
                return baseComplexView.Views;
            }

            return new List<IBaseView>();
        }

        private void W_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var iBaseView in GetViews(sender as Window))
            {
                var gridView = iBaseView.GridView;
                if (SettingsWrapper.Instance.GridSettingsDictionary.TryGetValue(iBaseView.ViewName, out SettingsWrapper.GridSettings settings) == true)
                {
                    for (int i = 0; i < gridView.Columns.Count; i++)
                    {
                        var columnSetting = settings.ListGridColumnSettings[i];
                        gridView.Columns[i].Width = columnSetting.ColumnWidth;
                        var header = gridView.Columns[i].Header as HeaderFilterBaseModel;
                        if (header != null)
                        {
                            var filterValue = settings.ListGridColumnSettings[i].FilterValue;
                            if (filterValue != null)
                            {
                                //int is deserialized at long, so need ChangeType to correct type to prevent binding exception
                                filterValue = System.Convert.ChangeType(filterValue, header.PropertyType);
                            }

                            header.DisableChangedAction(p =>
                            {
                                p.FilterValue = filterValue;
                                p.IsUsed = settings.ListGridColumnSettings[i].IsUsed;
                                p.Predicate = settings.ListGridColumnSettings[i].Predicate;
                                p.IsSorted = settings.ListGridColumnSettings[i].SortDirection;
                            });
                        }
                    }
                }
            }
        }

        private void W_Closed(object sender, System.EventArgs e)
        {
            foreach (var iBaseView in GetViews(sender as Window))
            {
                var gridView = iBaseView.GridView;
                var viewName = iBaseView.ViewName;
                if (SettingsWrapper.Instance.GridSettingsDictionary.TryGetValue(viewName, out SettingsWrapper.GridSettings settings) == false)
                {
                    settings = new SettingsWrapper.GridSettings();
                    for (int i = 0; i < gridView.Columns.Count; i++)
                    {
                        settings.ListGridColumnSettings.Add(new SettingsWrapper.GridColumnSettings());
                    }
                    SettingsWrapper.Instance.GridSettingsDictionary.Add(viewName, settings);
                }

                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    settings.ListGridColumnSettings[i].ColumnWidth = gridView.Columns[i].Width;
                    var header = gridView.Columns[i].Header as HeaderFilterBaseModel;
                    if (header != null)
                    {
                        settings.ListGridColumnSettings[i].FilterValue = header.FilterValue;
                        settings.ListGridColumnSettings[i].IsUsed = header.IsUsed;
                        settings.ListGridColumnSettings[i].Predicate = header.Predicate;
                        settings.ListGridColumnSettings[i].SortDirection = header.IsSorted;
                    }
                }
            }
        }
    }
}
