using System.Windows.Forms;
using MediatR;
using MediatRPad.Controls;
using MediatRPad.Notifications;
using MediatRPad.Properties;

namespace MediatRPad.MessageHandlers
{
    [ToolBarButtonMetaData(MenuConstants.Options.Save, MenuConstants.Order.Save, MenuConstants.Names.File)]
    public class SaveFileMessage : IRequest { }

    public class SaveFileMessageHandler : IRequestHandler<SaveFileMessage>
    {
        private readonly IMediator _mediator;

        public SaveFileMessageHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Handle(SaveFileMessage message)
        {
            var saveDialog = new SaveFileDialog
            {
                Filter = Settings.OpenFileDialog_Filter
            };

            if(saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var stream = saveDialog.OpenFile())
            {
                _mediator.Publish(new SaveFileDialogResultSuccessfulNotification { FileStream = stream });
            }
        }
    }
}