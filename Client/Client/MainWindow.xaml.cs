using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClient.View;
using huypq.SmtWpfClient.ViewModel;
using System.Windows;
using Client.View.Smt;
using System.Windows.Controls;
using SimpleDataGrid.ViewModel;
using System.Collections.Generic;
using huypq.wpf.Utils;
using Microsoft.Extensions.Logging;
using huypq.Logging;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IDataService _dataService;
        LoginViewModel _loginViewModel;
        List<Window> _windowList = new List<Window>();
        bool _isShuttingDown = false;

        public MainWindow()
        {
            Init();

            InitializeComponent();

            _loginViewModel = loginView.DataContext as LoginViewModel;

            _loginViewModel.TenantName = SettingsWrapper.Instance.Tenant;
            _loginViewModel.Email = SettingsWrapper.Instance.User;

            if (_dataService.IsLoggedIn() == true)
            {
                _loginViewModel.IsLoggedIn = true;
                _loginViewModel.IsTenant = SettingsWrapper.Instance.IsTenant;
            }

            _loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;
            Closing += MainWindow_Closing;
            Closed += MainWindow_Closed;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_windowList.Count > 0)
            {
                if (MessageBox.Show("Close Main window will close all windows and app, are you sure you want to close ?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }

            SettingsWrapper.Instance.Token = _dataService.GetBase64ProtectedToken();
            SettingsWrapper.Instance.IsTenant = _dataService.IsTenant();
        }

        private void MainWindow_Closed(object sender, System.EventArgs e)
        {
            _isShuttingDown = true;
            foreach (var w in _windowList)
            {
                w.Close();
            }
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
            ServiceLocator.AddTypeMapping(typeof(ILoggerProvider), typeof(LoggerProviderWithOptions), true, new LoggerProviderWithOptions.Options()
            {
                Filter = (category, logLevel) => logLevel >= LogLevel.Information,
                IsIncludeScope = true,
                Processor = new LoggerBatchingProcessor(1000, 1024, 1024, @"logs", 31, 20 * 1024 * 1024)
            });

            ServiceLocator.AddTypeMapping(typeof(IViewModelFactory), typeof(ViewModelFactory), true, new ViewModelFactory.Options()
            {
                ViewModelNamespace = "Client.ViewModel",
                ViewModelAssembly = System.Reflection.Assembly.GetExecutingAssembly()
            });

            ServiceLocator.AddTypeMapping(typeof(IDataService), typeof(ProtobufDataService), true, new ProtobufDataService.Options()
            {
                Token = SettingsWrapper.Instance.Token,
                IsTenant = SettingsWrapper.Instance.IsTenant,
                RootUri = SettingsWrapper.Instance.Server
            });

            _dataService = ServiceLocator.Get<IDataService>();

            ReferenceDataManager<Shared.rChanhDto>.Instance.Init((chanh) =>
            {
                chanh.MaBaiXeNavigation = ReferenceDataManager<Shared.rBaiXeDto>.Instance.GetByID(chanh.MaBaiXe);
            });
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            (loginView.DataContext as LoginViewModel).Logout();
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new ChangePasswordWindow()
            {
                Owner = this
            };
            w.ShowDialog();
        }

        private void ManageUserButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new Window()
            {
                Content = new ManageUserView(),
                Owner = this
            };
            w.ShowDialog();
        }

        Window logViewer;
        private void LogViewerButton_Click(object sender, RoutedEventArgs e)
        {
            if (logViewer == null)
            {
                logViewer = new Window()
                {
                    Title = "Log Viewer",
                    WindowState = WindowState.Maximized,
                    Content = new LogViewer.LogViewerControl()
                };
                logViewer.Closing += LogViewer_Closing;
                logViewer.Closed += LogViewer_Closed;
                logViewer.Show();
                _windowList.Add(logViewer);
            }
            else
            {
                logViewer.WindowState = WindowState.Maximized;
                logViewer.Activate();
            }
        }

        private void LogViewer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            logViewer.Closing -= LogViewer_Closing;
            RemoveFromWindowList(sender as Window);
        }

        private void LogViewer_Closed(object sender, System.EventArgs e)
        {
            logViewer.Closed -= LogViewer_Closed;
            logViewer = null;
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
            w.Closing += W_Closing;
            w.Closed += W_Closed;

            _windowList.Add(w);

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

        private void W_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoveFromWindowList(sender as Window);
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

        private void RemoveFromWindowList(Window w)
        {
            if (_isShuttingDown == true)
            {
                return;
            }

            _windowList.Remove(w);
        }
    }
}
