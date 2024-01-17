namespace Library.Infrastructure.ExceptionHandling
{
    public interface IMessageNotificationProvider
    {
        void ShowError(string message);
        void ShowWarning(string message, string displayMessage);
        void ShowInformation(string message);

    }
}