namespace Library.Infrastructure.ExceptionHandling;

public class ExceptionHandler : IExceptionHandler
{
    private readonly IMessageNotificationProvider _infoPopupProvider;
    private readonly IApplicationLogger _applicationLogger;

    internal ExceptionHandler()
    {
        _applicationLogger = new DefaultApplicationLogger();
        _infoPopupProvider = new DefaultMessageNotificationProvider();
    }

    internal ExceptionHandler(IMessageNotificationProvider infoPopupProvider, IApplicationLogger applicationLogger)
    {
        _applicationLogger = applicationLogger;
        _infoPopupProvider = infoPopupProvider;
    }


    public delegate void ApplicationExitHandler();
    public event ApplicationExitHandler? ApplicationExitEvent;
    public void Handle(Exception exception)
    {
        if (exception is AppException appException)
        {
            Log(appException);
            if (appException.IsRecoverable.Equals(ExceptionType.RECOVERABLE))
            {
                _infoPopupProvider.ShowWarning("Warning", appException.DisplayMessage);
            }
            else
            {
                _infoPopupProvider.ShowError(appException.DisplayMessage);
                ApplicationExitEvent?.Invoke();
            }
        }
        else
        {
            Log(exception);
            _infoPopupProvider.ShowError("An unexpected error occurred, application will now exit!\n\rIf the problem persists please contact support");
            _applicationLogger.OnExit();
            ApplicationExitEvent?.Invoke();
        }
    }

    private void Log(Exception exception)
    {
        _applicationLogger.Error(exception);
    }


    private void Log(AppException appException)
    {
        switch (appException.Severity)
        {
            case ExceptionSeverity.INFO:
                {
                    _applicationLogger.Information(appException);
                }
                break;
            case ExceptionSeverity.WARNING:
                {
                    _applicationLogger.Warning(appException);
                }
                break;
            case ExceptionSeverity.ERROR:
                {
                    _applicationLogger.Error(appException);
                }
                break;
        }
    }
}
