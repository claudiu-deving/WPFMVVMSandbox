namespace WPFMVVMSandbox.ViewModel.Utilities;

public interface IDispatcherService
{
    void Invoke(Action action);
}
