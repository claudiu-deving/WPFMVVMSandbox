#nullable enable
using System.Globalization;
using System.Windows.Controls;

namespace Library.MVVM;

public interface IValidationRule
{
    ValidationResult Validate(object? value, CultureInfo cultureInfo);
}
