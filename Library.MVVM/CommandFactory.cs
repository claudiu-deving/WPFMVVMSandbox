#nullable enable
namespace Library.MVVM;

public class CommandFactory : IFactory
{
    private readonly TaskScheduler _uiTaskScheduler;

    public CommandFactory()
    {
        _uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    }
    public CommandBase Create(Action<object> execute)
    {
        return new CommandBase(execute, _uiTaskScheduler);
    }

    public CommandBase Create(Func<object, Task> executeAsync)
    {
        return new CommandBase(executeAsync, _uiTaskScheduler);
    }

    public CommandBase Create(Action<object> execute, Func<object, bool>? canExecute)
    {
        return new CommandBase(execute, canExecute, _uiTaskScheduler);
    }

    public CommandBase Create(Func<object, Task> executeAsync, Func<object, bool>? canExecute)
    {
        return new CommandBase(executeAsync, canExecute, _uiTaskScheduler);
    }
}
