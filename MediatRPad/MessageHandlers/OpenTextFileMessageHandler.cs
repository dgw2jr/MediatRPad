using System.Windows.Forms;
using MediatR;
using MediatRPad.Messages;
using MediatRPad.Properties;

namespace MediatRPad.MessageHandlers
{
    public class OpenTextFileMessageHandler : IRequestHandler<OpenTextFileMessage>
    {
        private readonly IMediator _mediator;

        public OpenTextFileMessageHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Handle(OpenTextFileMessage message)
        {
            var dlg = new OpenFileDialog
            {
                Filter = Resources.OpenFileDialog_Filter
            };

            if (dlg.ShowDialog() == DialogResult.Cancel) return;

            using (var stream = dlg.OpenFile())
            {
                _mediator.Publish(new OpenFileDialogResultSuccessfulNotification { FileStream = stream });
            }
        }
    }
}