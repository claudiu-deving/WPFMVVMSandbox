#nullable enable
namespace Library.MVVM;

public interface IValidationService
{
    void Validate<T>(string propertyName, T? value, List<IValidationRule>? rules = null);
}
