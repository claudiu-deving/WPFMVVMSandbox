#nullable enable
using System.Globalization;
using System.Windows.Controls;

namespace Library.MVVM;

public class InlineValidationRule(Func<object?, ValidationResult> validate) : ValidationRule, IValidationRule
{
    private readonly Func<object?, ValidationResult> _validate = validate;


    public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
    {
        return _validate(value);
    }
}