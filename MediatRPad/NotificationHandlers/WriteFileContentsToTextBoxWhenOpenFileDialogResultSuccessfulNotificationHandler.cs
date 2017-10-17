using System.IO;
using MediatR;
using MediatRPad.Controls;
using MediatRPad.Notifications;

namespace MediatRPad.NotificationHandlers
{
    public class WriteFileContentsToTextBoxWhenOpenFileDialogResultSuccessfulNotificationHandler : INotificationHandler<OpenFileDialogResultSuccessfulNotification>
    {
        private readonly FileContentsTextBox _textBox;

        public WriteFileContentsToTextBoxWhenOpenFileDialogResultSuccessfulNotificationHandler(FileContentsTextBox textBox)
        {
            _textBox = textBox;
        }

        public void Handle(OpenFileDialogResultSuccessfulNotification notification)
        {
            using (var reader = new StreamReader(notification.FileStream))
            {
                _textBox.Text = reader.ReadToEnd();
            }
        }
    }
}