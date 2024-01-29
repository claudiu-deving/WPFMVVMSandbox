namespace Library.Infrastructure.ExceptionHandling;


public class AppException : Exception
{
    public new Exception? InnerException { get; }
    public ExceptionType IsRecoverable { get; }
    public ExceptionVisibility IsShownToUser { get; }
    public ExceptionSeverity Severity { get; }
    public string DisplayMessage { get; }
    public AppException(
        string message,
        string displayMessage,
        ExceptionType isRecoverable,
        ExceptionVisibility isShownToUser,
        ExceptionSeverity severity,
        Exception? innerException) : base(message)
    {
        IsRecoverable = isRecoverable;
        IsShownToUser = isShownToUser;
        Severity = severity;
        DisplayMessage = displayMessage;
        InnerException = innerException;
    }
}