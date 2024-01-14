using System.Windows;

using WPFMVVMSandbox.ViewModel.Utilities;

namespace WPFMVVMSandbox.View.Services;


public class DispatcherService : IDispatcherService
{
    public void Invoke(Action action)
    {
        Application.Current.Dispatcher.Invoke(action);
    }
}
