using MediatR;
using MediatRPad.Controls;
using MediatRPad.Notifications;

namespace MediatRPad.NotificationHandlers
{
    public class SetStatusBarLabelTextWhenOpenFileDialogResultSuccessfulNotificationHandler : INotificationHandler<OpenFileDialogResultSuccessfulNotification>
    {
        private readonly BottomStatusStripLabel _label;

        public SetStatusBarLabelTextWhenOpenFileDialogResultSuccessfulNotificationHandler(BottomStatusStripLabel label)
        {
            _label = label;
        }

        public void Handle(OpenFileDialogResultSuccessfulNotification notification)
        {
            _label.Text = notification.FileName;
        }
    }
}