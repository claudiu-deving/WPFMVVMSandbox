#nullable enable
namespace Library.Infrastructure.ExceptionHandling;

public class AppExceptionBuilder : IAppExceptionBuilder
{
    private string _message = string.Empty;
    private string _displayMessage = string.Empty; // Default to empty
    private Exception? _innerException = null;
    private ExceptionSeverity _severity = ExceptionSeverity.WARNING;
    private ExceptionVisibility _visibility = ExceptionVisibility.SHOWN_TO_USER; // Default to visible
    private ExceptionType _exceptionType = ExceptionType.UNRECOVERABLE;

    public AppExceptionBuilder WithMessage(string message)
    {
        _message = message;
        return this;
    }

    public AppExceptionBuilder WithDisplayMessage(string displayMessage)
    {
        _displayMessage = displayMessage;
        return this;
    }

    public AppExceptionBuilder WithSeverity(ExceptionSeverity severity)
    {
        _severity = severity;
        return this;
    }

    public AppExceptionBuilder AsNonVisible()
    {
        _visibility = ExceptionVisibility.NOT_SHOWN_TO_USER;
        _displayMessage = string.Empty;
        return this;
    }
    public AppExceptionBuilder AsRecoverable()
    {
        _exceptionType = ExceptionType.RECOVERABLE;
        return this;
    }

    public AppExceptionBuilder WithInnerException(Exception innerException)
    {
        _message = innerException.Message;
        _innerException = innerException;
        return this;
    }

    public AppException Build()
    {
        return new AppException(_message, _displayMessage, _exceptionType, _visibility, _severity, _innerException);
    }
}