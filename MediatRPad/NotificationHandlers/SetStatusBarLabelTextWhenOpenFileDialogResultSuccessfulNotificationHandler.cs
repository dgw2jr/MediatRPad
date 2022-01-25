using MediatR;
using MediatRPad.Controls;
using MediatRPad.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRPad.NotificationHandlers
{
    public class SetStatusBarLabelTextWhenOpenFileDialogResultSuccessfulNotificationHandler : INotificationHandler<OpenFileDialogResultSuccessfulNotification>
    {
        private readonly BottomStatusStripLabel _label;

        public SetStatusBarLabelTextWhenOpenFileDialogResultSuccessfulNotificationHandler(BottomStatusStripLabel label)
        {
            _label = label;
        }

        public async Task Handle(OpenFileDialogResultSuccessfulNotification notification, CancellationToken token)
        {
            _label.Text = notification.FileName;

            await Task.CompletedTask;
        }
    }
}