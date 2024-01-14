using WPFMVVMSandbox.ViewModel.Utilities;

namespace WPFMVVMSandbox.View.Local;

public class CommandFactory(IDispatcherService dispatcherService) : IFactory
{
    private readonly IDispatcherService _dispatcherService = dispatcherService;

    public CommandBase Create(Action<object> execute)
    {
        return new CommandBase(execute, _dispatcherService);
    }

    public CommandBase Create(Func<object, Task> executeAsync)
    {
        return new CommandBase(executeAsync, _dispatcherService);
    }

    public CommandBase Create(Action<object> execute, Func<object, bool>? canExecute)
    {
        return new CommandBase(execute, canExecute, _dispatcherService);
    }

    public CommandBase Create(Func<object, Task> executeAsync, Func<object, bool>? canExecute)
    {
        return new CommandBase(executeAsync, canExecute, _dispatcherService);
    }
}
