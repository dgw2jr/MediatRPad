using System.Resources;
using System.Windows.Forms;
using MediatR;
using MediatRPad.Controls;
using MediatRPad.Properties;

namespace MediatRPad.MessageHandlers
{
    [ToolBarButtonMetaData(MenuConstants.Options.About, MenuConstants.Order.About, MenuConstants.Names.Help)]
    public class AboutMessage : IRequest { }

    public class AboutMessageHandler : IRequestHandler<AboutMessage>
    {
        public void Handle(AboutMessage message)
        {
            MessageBox.Show(new ResourceManager(typeof(Resources)).GetString("AboutText"));
        }
    }
}