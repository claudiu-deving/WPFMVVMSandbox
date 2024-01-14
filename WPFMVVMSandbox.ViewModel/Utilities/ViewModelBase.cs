using System.Collections;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFMVVMSandbox.ViewModel.Utilities;


public class ErrorManager : INotifyDataErrorInfo
{
    public bool HasErrors { get; private set; }

    private readonly ConcurrentDictionary<string, List<string>> _errors = [];
    public IEnumerable? GetErrors([CallerMemberName] string? propertyName = null)
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

    public void AddErrors(List<string> errors, [CallerMemberName] string? propertyName = null)
    {
        if (propertyName is null) { return; }
        _errors.AddOrUpdate(propertyName, errors, (key, existingVal) =>
        {
            existingVal.AddRange(errors);
            return existingVal;
        });
        OnErrorsChanged(propertyName);
    }


    public bool ClearErrors([CallerMemberName] string? propertyName = null)
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

public class ViewModelBase : INotifyPropertyChanged
{
    public ViewModelBase()
    {
        ErrorManager = new ErrorManager();
    }

    protected ErrorManager ErrorManager { get; }

    /// <summary>
    /// Event that is fired when a property is changed
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Method that is called when a property is changed
    /// </summary>
    /// <param name="propertyName">The name of the parameter, leave empty when the caller is property's setter.</param>
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
