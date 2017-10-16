using System.IO;
using MediatR;

namespace MediatRPad
{
    public class OpenFileDialogResultSuccessfulNotification : INotification
    {
        public Stream FileStream { get; set; }
    }
}