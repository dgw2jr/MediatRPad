using System.IO;
using MediatR;
using MediatRPad.Controls;

namespace MediatRPad
{
    public class PrintContentsToTextBoxWhenOpenFileDialogResultSuccessfulNotificationHandler : INotificationHandler<OpenFileDialogResultSuccessfulNotification>
    {
        private readonly FileContentsTextBox _textBox;

        public PrintContentsToTextBoxWhenOpenFileDialogResultSuccessfulNotificationHandler(FileContentsTextBox textBox)
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