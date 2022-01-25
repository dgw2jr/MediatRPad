using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediatR;
using MediatRPad.Controls;
using MediatRPad.Notifications;
using MediatRPad.Properties;

namespace MediatRPad.MessageHandlers
{
    [ToolBarButtonMetaData(MenuConstants.Options.Save, MenuConstants.Order.Save, MenuConstants.Names.File)]
    public class SaveFileMessage : IRequest { }

    public class SaveFileMessageHandler : IRequestHandler<SaveFileMessage, Unit>
    {
        private readonly IMediator _mediator;

        public SaveFileMessageHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(SaveFileMessage message, CancellationToken token)
        {
            var saveDialog = new SaveFileDialog
            {
                Filter = Settings.OpenFileDialog_Filter
            };

            if(saveDialog.ShowDialog() != DialogResult.OK)
            {
                return await Unit.Task;
            }

            using (var stream = saveDialog.OpenFile())
            {
                await _mediator.Publish(new SaveFileDialogResultSuccessfulNotification { FileStream = stream });
            }

            return await Unit.Task;
        }
    }
}