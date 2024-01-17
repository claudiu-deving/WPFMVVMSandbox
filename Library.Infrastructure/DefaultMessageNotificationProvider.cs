using System.Windows;

namespace Library.Infrastructure.ExceptionHandling
{

    public class DefaultMessageNotificationProvider : IMessageNotificationProvider
    {
        public void ShowError(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowInformation(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowWarning(string message, string displayMessage)
        {
            MessageBox.Show(message);
        }
    }
}
