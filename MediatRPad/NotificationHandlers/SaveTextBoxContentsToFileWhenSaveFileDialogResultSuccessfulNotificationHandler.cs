using System.IO;
using MediatR;
using MediatRPad.Controls;
using MediatRPad.Notifications;

namespace MediatRPad.NotificationHandlers
{
    public class SaveTextBoxContentsToFileWhenSaveFileDialogResultSuccessfulNotificationHandler : INotificationHandler<SaveFileDialogResultSuccessfulNotification>
    {
        private readonly FileContentsTextBox _textBox;

        public SaveTextBoxContentsToFileWhenSaveFileDialogResultSuccessfulNotificationHandler(FileContentsTextBox textBox)
        {
            _textBox = textBox;
        }

        public void Handle(SaveFileDialogResultSuccessfulNotification notification)
        {
            using (var writer = new StreamWriter(notification.FileStream))
            {
                writer.Write(_textBox.Text);
            }
        }
    }
}