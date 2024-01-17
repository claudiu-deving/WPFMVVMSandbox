#nullable enable
using System.Globalization;
using System.Windows.Controls;

namespace Library.MVVM;

public class IsNotEmptyAttribute : ValidationAttribute
{
    public static ValidationRule? Rule { get; private set; }
    public override IValidationRule CreateRule()
    {
        var rule = new InlineValidationRule(
            value =>
            {
                if (string.IsNullOrEmpty(value?.ToString()))
                {
                    return new ValidationResult(false, "Value cannot be empty.");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            });
        Rule = rule;
        return rule;
    }
}

public class DateLaterAttribute : ValidationAttribute
{
    public override IValidationRule CreateRule()
    {
        return new InlineValidationRule(
                       value =>
                       {

                           if (value == null) return new ValidationResult(false, "Value cannot be empty.");

                           if (value is DateTime dateTimeValue)
                           {
                               if (dateTimeValue <= DateTime.Now)
                               {
                                   return ValidationResult.ValidResult;
                               }
                               else
                               {
                                   return new ValidationResult(false, "Date cannot be later than today.");
                               }
                           }

                           return new ValidationResult(false, "Value must be a date.");
                       });
    }
}

public class IsNotStringRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value is string stringValue)
        {
            double number;
            if (!double.TryParse(stringValue, out number))
            {
                return new ValidationResult(false, "Please enter a valid number.");
            }
        }

        return ValidationResult.ValidResult;
    }
}