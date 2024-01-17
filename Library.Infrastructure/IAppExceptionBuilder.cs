
namespace Library.Infrastructure.ExceptionHandling
{
    public interface IAppExceptionBuilder
    {
        AppExceptionBuilder AsNonVisible();
        AppExceptionBuilder AsRecoverable();
        AppException Build();
        AppExceptionBuilder WithDisplayMessage(string displayMessage);
        AppExceptionBuilder WithInnerException(Exception innerException);
        AppExceptionBuilder WithMessage(string message);
        AppExceptionBuilder WithSeverity(ExceptionSeverity severity);
    }
}