using Library.MVVM;

using System.Windows;


namespace WPFMVVMSandbox.View.Services;


public class DispatcherService : IDispatcherService
{
    public void Invoke(Action action)
    {
        Application.Current.Dispatcher.Invoke(action);
    }
}
