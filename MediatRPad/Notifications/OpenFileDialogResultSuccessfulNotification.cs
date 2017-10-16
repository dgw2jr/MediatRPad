using System.IO;
using MediatR;

namespace MediatRPad.Notifications
{
    public class OpenFileDialogResultSuccessfulNotification : INotification
    {
        public Stream FileStream { get; set; }
    }
}