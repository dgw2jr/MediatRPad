using System.IO;
using System.Threading;
using System.Threading.Tasks;
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

        public async Task Handle(SaveFileDialogResultSuccessfulNotification notification, CancellationToken token)
        {
            using (var writer = new StreamWriter(notification.FileStream))
            {
                writer.Write(_textBox.Text);
            }

            await Task.CompletedTask;
        }
    }
}