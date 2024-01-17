using Library.Infrastructure.ExceptionHandling;

using System.Windows;

namespace WPFMVVMSandbox.View;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var exceptionHandler = ExceptionHandlerProvider.DefaultImplementation();
        base.OnStartup(e);
        Dispatcher.UnhandledException += (sender, args) =>
        {
            exceptionHandler.Handle(args.Exception);
            args.Handled = true;
        };
    }
}