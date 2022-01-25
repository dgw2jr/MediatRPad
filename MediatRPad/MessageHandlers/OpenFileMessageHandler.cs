using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediatR;
using MediatRPad.Controls;
using MediatRPad.Notifications;
using MediatRPad.Properties;

namespace MediatRPad.MessageHandlers
{
    [ToolBarButtonMetaData(MenuConstants.Options.Open, MenuConstants.Order.Open, MenuConstants.Names.File)]
    public class OpenFileMessage : IRequest { }

    public class OpenFileMessageHandler : IRequestHandler<OpenFileMessage, Unit>
    {
        private readonly IMediator _mediator;

        public OpenFileMessageHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(OpenFileMessage message, CancellationToken token)
        {
            var dlg = new OpenFileDialog
            {
                Filter = Settings.OpenFileDialog_Filter
            };

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return await Unit.Task;
            }

            using (var stream = dlg.OpenFile())
            {
               await _mediator.Publish(new OpenFileDialogResultSuccessfulNotification { FileStream = stream, FileName = dlg.FileName });
            }

            return await Unit.Task;
        }
    }
}