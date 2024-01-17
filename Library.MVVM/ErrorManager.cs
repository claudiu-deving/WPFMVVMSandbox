#nullable enable
using System.Collections.Concurrent;


namespace Library.MVVM;

public class ErrorManager : INotifyDataErrorInfo, IErrorManager
{
    public bool HasErrors { get; private set; }

    private readonly ConcurrentDictionary<string, List<string>> _errors = [];
    public IEnumerable? GetErrors(string propertyName)
    {
        if (propertyName is null) { return null; }
        if (string.IsNullOrEmpty(propertyName))
        {
            return _errors.Values.SelectMany(x => x);
        }

        if (_errors.ContainsKey(propertyName) && (_errors[propertyName] != null))
        {
            return _errors[propertyName];
        }

        return null;
    }

    public void AddErrors(IEnumerable<string> errors, string propertyName)
    {
        if (propertyName is null) { return; }
        _errors.AddOrUpdate(propertyName, errors.ToList(), (key, existingVal) =>
        {
            existingVal.AddRange(errors);
            return existingVal;
        });
        OnErrorsChanged(propertyName);
    }


    public bool ClearErrors(string propertyName)
    {
        if (propertyName is null) { return false; }
        if (!_errors.ContainsKey(propertyName))
        {
            return false;
        }

        if (_errors.TryRemove(propertyName, out _))
        {
            OnErrorsChanged(propertyName);
            return true;
        }
        return false;
    }
    private void OnErrorsChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        HasErrors = _errors.Any();
    }
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
}
