using Library.Infrastructure.ExceptionHandling;

using Tekla.Structures;
using System.Windows;

namespace WPFMVVMSandbox.View;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        new Tekla.Structures.Model.Model().CommitChanges("");
    }
}