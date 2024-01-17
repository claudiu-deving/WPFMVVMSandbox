#nullable enable
using System.Globalization;

namespace Library.MVVM;

internal class ValidationService : IValidationService
{
    private readonly IErrorManager _errorManager;

    public ValidationService(IErrorManager errorManager)
    {
        _errorManager = errorManager;
    }

    public void Validate<T>(string propertyName, T? value, List<IValidationRule>? rules = null)
    {
        if (rules == null) return;
        foreach (var rule in rules)
        {
            if (rule is null) throw new ArgumentException("Rule cannot be null");
            var validationResult = rule.Validate(value, CultureInfo.InvariantCulture);
            if (!validationResult.IsValid)
            {
                _errorManager.AddErrors([validationResult.ErrorContent.ToString()], propertyName);
            }
            else
            {
                _errorManager.ClearErrors(propertyName);
            }
        }
    }
}
