using System.Windows.Forms;
using MediatR;
using MediatRPad.Messages;

namespace MediatRPad.MessageHandlers
{
    public class SaveFileMessageHandler : IRequestHandler<SaveFileMessage>
    {
        public void Handle(SaveFileMessage message)
        {
            MessageBox.Show(@"Not yet implemented! Schucks...");
        }
    }
}