namespace Library.Infrastructure.ExceptionHandling;

public interface IApplicationLogger
{
    void Error(Exception exception);
    void Information(Exception message);
    void Warning(Exception message);
    void OnExit();
}
