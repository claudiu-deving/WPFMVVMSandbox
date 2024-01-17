namespace Library.MVVM;

public interface IFactory
{
    CommandBase Create(Action<object> execute);
    CommandBase Create(Func<object, Task> executeAsync);
    CommandBase Create(Action<object> execute, Func<object, bool>? canExecute);
    CommandBase Create(Func<object, Task> executeAsync, Func<object, bool>? canExecute);
}
