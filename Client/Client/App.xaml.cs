using huypq.SmtWpfClient;
using huypq.wpf.Utils;
using System.Windows;
using Microsoft.Extensions.Logging;
using huypq.Logging;
using huypq.SmtWpfClient.Abstraction;
using System;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Startup += App_Startup;
            Exit += App_Exit;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            SettingsWrapper.Load();

            //apply Window Style in App.xaml to all Window type
            FrameworkElement.StyleProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata
            {
                DefaultValue = FindResource(typeof(Window))
            });

            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            //apply language to all FrameworkElement
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata()
            {
                DefaultValue = System.Windows.Markup.XmlLanguage.GetLanguage(System.Threading.Thread.CurrentThread.CurrentUICulture.Name)
            });

            Init();

            StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            SettingsWrapper.Save();
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
        }
    }
}
