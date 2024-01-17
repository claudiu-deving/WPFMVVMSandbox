#nullable enable
namespace Library.MVVM;

public interface IRuleValidationFactory
{
    IValidationRule GetValidationRule(Attribute attribute);
}
