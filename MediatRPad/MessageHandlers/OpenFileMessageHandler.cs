using System.Windows.Forms;
using MediatR;
using MediatRPad.Controls;
using MediatRPad.Notifications;
using MediatRPad.Properties;

namespace MediatRPad.MessageHandlers
{
    [ToolBarButtonMetaData("Open", 1, "File")]
    public class OpenFileMessage : IRequest { }

    public class OpenFileMessageHandler : IRequestHandler<OpenFileMessage>
    {
        private readonly IMediator _mediator;

        public OpenFileMessageHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Handle(OpenFileMessage message)
        {
            var dlg = new OpenFileDialog
            {
                Filter = Resources.OpenFileDialog_Filter
            };

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var stream = dlg.OpenFile())
            {
                _mediator.Publish(new OpenFileDialogResultSuccessfulNotification { FileStream = stream, FileName = dlg.FileName });
            }
        }
    }
}