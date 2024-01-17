#nullable enable
namespace Library.MVVM;

public abstract class ValidationAttribute : Attribute
{
    public abstract IValidationRule CreateRule();
}
