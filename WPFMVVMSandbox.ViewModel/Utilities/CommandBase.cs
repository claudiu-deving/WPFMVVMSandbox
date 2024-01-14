using System.Windows.Input;


namespace WPFMVVMSandbox.ViewModel.Utilities;

public class CommandBase : ICommand
{
    private readonly Func<object, bool>? _canExecute;
    private readonly Delegate _execute;
    private readonly IDispatcherService _dispatcherService;

    /// <summary>
    /// Event that is fired when the command's state changes
    /// </summary>
    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// Creates a new command.
    /// </summary>
    /// <param name="execute"></param>
    public CommandBase(Action<object> execute, IDispatcherService dispatcherService)
        : this(execute, null, dispatcherService)
    {
        _dispatcherService = dispatcherService;
    }

    /// <summary>
    /// Creates a new command using an async method.
    /// </summary>
    /// <param name="executeAsync"></param>
    public CommandBase(Func<object, Task> executeAsync, IDispatcherService dispatcherService)
        : this(executeAsync, null, dispatcherService)
    {
        _dispatcherService = dispatcherService;
    }

    /// <summary>
    /// Creates a new command and it's status checker.
    /// </summary>
    /// <param name="execute"></param>
    /// <param name="canExecute"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public CommandBase(Action<object> execute, Func<object, bool>? canExecute, IDispatcherService dispatcherService)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
        _dispatcherService = dispatcherService;
    }

    /// <summary>
    /// Creates a new command using an async method and it's status checker.
    /// </summary>
    /// <param name="executeAsync"></param>
    /// <param name="canExecute"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public CommandBase(Func<object, Task> executeAsync, Func<object, bool>? canExecute, IDispatcherService dispatcherService)
    {
        _execute = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
        _canExecute = canExecute;
        _dispatcherService = dispatcherService;
    }

    /// <summary>
    /// Checks if the command can be executed.
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public bool CanExecute(object? parameter)
    {
        return (_canExecute == null || _canExecute(parameter)) && (_execute is Action<object> || _execute is Func<object, Task>);
    }

    /// <summary>
    /// Executes the method.
    /// </summary>
    /// <param name="parameter"></param>
    public async void Execute(object? parameter)
    {
        if (_execute is Func<object, Task> executeAsync)
        {
            await executeAsync(parameter);
        }
        else if (_execute is Action<object> execute)
        {
            execute(parameter);
        }
    }

    /// <summary>
    /// For rechecking whether or not the command can be executed.
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
        _dispatcherService.Invoke(() =>
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        });
    }
}
