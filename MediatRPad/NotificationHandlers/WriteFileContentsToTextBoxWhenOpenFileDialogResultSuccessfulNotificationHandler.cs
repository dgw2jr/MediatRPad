using System.IO;
using System.Threading;
using System.Threading.Tasks;
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

        public async Task Handle(OpenFileDialogResultSuccessfulNotification notification, CancellationToken token)
        {
            using (var reader = new StreamReader(notification.FileStream))
            {
                _textBox.Text = reader.ReadToEnd();
            }

            await Task.CompletedTask;
        }
    }
}