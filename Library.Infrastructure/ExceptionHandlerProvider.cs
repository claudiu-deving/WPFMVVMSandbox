namespace Library.Infrastructure.ExceptionHandling;

public class ExceptionHandlerProvider : IExceptionHandlerProvider
{
    private IMessageNotificationProvider? _infoPopupProvider;
    private IApplicationLogger? _applicationLogger;


    public ExceptionHandlerProvider HasMessageNotificationProvider(IMessageNotificationProvider infoPopupProvider)
    {
        _infoPopupProvider = infoPopupProvider;
        return this;
    }

    public ExceptionHandlerProvider HasApplicationLogger(IApplicationLogger applicationLogger)
    {
        _applicationLogger = applicationLogger;
        return this;
    }

    public ExceptionHandler Build()
    {
        _infoPopupProvider ??= new DefaultMessageNotificationProvider();
        _applicationLogger ??= new DefaultApplicationLogger();

        return new ExceptionHandler(_infoPopupProvider, _applicationLogger);
    }

    public static ExceptionHandler DefaultImplementation()
    {
        return new ExceptionHandler();
    }
}
