using System.Windows.Forms;
using MediatR;
using MediatRPad.Messages;
using MediatRPad.Properties;

namespace MediatRPad.MessageHandlers
{
    public class AboutMessageHandler : IRequestHandler<AboutMessage>
    {
        public void Handle(AboutMessage message)
        {
            MessageBox.Show(Resources.AboutText);
        }
    }
}