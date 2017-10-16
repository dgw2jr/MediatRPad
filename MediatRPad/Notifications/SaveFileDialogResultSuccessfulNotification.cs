using System.IO;
using MediatR;

namespace MediatRPad.Notifications
{
    public class SaveFileDialogResultSuccessfulNotification : INotification
    {
        public Stream FileStream { get; set; }
    }
}