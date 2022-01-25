using System.Drawing.Printing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediatR;
using MediatRPad.Controls;

namespace MediatRPad.MessageHandlers
{
    [ToolBarButtonMetaData(MenuConstants.Options.Print, MenuConstants.Order.Print, MenuConstants.Names.File)]
    public class PrintFileMessage : IRequest { }

    public class PrintFileMessageHandler : IRequestHandler<PrintFileMessage, Unit>
    {
        public async Task<Unit> Handle(PrintFileMessage message, CancellationToken token)
        {
            var printDialog = new PrintDialog
            {
                AllowPrintToFile = true,
                AllowSelection = true,
                AllowSomePages = true
            };

            var printDocument = new PrintDocument
            {
                DocumentName = "Print Document"
            };

            printDialog.Document = printDocument;

            var result = printDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                return await Unit.Task;
            }

            printDialog.Document.Print();

            return await Unit.Task;
        }
    }
}