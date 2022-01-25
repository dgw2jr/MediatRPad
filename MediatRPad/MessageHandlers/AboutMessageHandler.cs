using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediatR;
using MediatRPad.Controls;
using MediatRPad.Properties;

namespace MediatRPad.MessageHandlers
{
    [ToolBarButtonMetaData(MenuConstants.Options.About, MenuConstants.Order.About, MenuConstants.Names.Help)]
    public class AboutMessage : IRequest { }

    public class AboutMessageHandler : IRequestHandler<AboutMessage, Unit>
    {
        public async Task<Unit> Handle(AboutMessage message, CancellationToken token)
        {
            MessageBox.Show(new ResourceManager(typeof(Resources)).GetString("AboutText"));

            return await Unit.Task;
        }
    }
}