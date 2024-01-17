#nullable enable
namespace Library.MVVM;

public interface IErrorManager
{
    bool HasErrors { get; }

    event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    void AddErrors(IEnumerable<string> errors, string propertyName);
    bool ClearErrors(string propertyName);
    IEnumerable? GetErrors(string propertyName);
}
