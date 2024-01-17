#nullable enable
namespace Library.MVVM;

public class RuleValidationFactory : IRuleValidationFactory
{
    public IValidationRule GetValidationRule(Attribute attribute)
    {
        if (attribute is ValidationAttribute validationAttribute)
        {
            return validationAttribute.CreateRule();
        }

        throw new ArgumentException("Attribute must be of type ValidationAttribute.");
    }
}
