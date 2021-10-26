using System.Windows.Forms;
using MediatR;
using MediatRPad.Controls;
using MediatRPad.Properties;

namespace MediatRPad.MessageHandlers
{
    [ToolBarButtonMetaData("About", 4, "Help")]
    public class AboutMessage : IRequest { }

    public class AboutMessageHandler : IRequestHandler<AboutMessage>
    {
        public void Handle(AboutMessage message)
        {
            MessageBox.Show(Resources.AboutText);
        }
    }
}