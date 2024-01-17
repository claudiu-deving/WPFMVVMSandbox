#nullable enable
namespace Library.MVVM;

public interface IDispatcherService
{
    void Invoke(Action action);
}
