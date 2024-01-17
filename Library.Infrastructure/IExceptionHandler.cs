namespace Library.Infrastructure.ExceptionHandling;

public interface IExceptionHandler
{
    void Handle(Exception exception);
}