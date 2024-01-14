using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFMVVMSandbox.ViewModel.Utilities
{
    public interface IErrorManager
    {
        bool HasErrors { get; }

        event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        void AddErrors(List<string> errors, [CallerMemberName] string? propertyName = null);
        bool ClearErrors([CallerMemberName] string? propertyName = null);
        IEnumerable? GetErrors([CallerMemberName] string? propertyName = null);
    }
}