using System.Drawing.Printing;
using System.Windows.Forms;
using MediatR;
using MediatRPad.Messages;

namespace MediatRPad.MessageHandlers
{
    public class PrintFileMessageHandler : IRequestHandler<PrintFileMessage>
    {
        public void Handle(PrintFileMessage message)
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
                return;
            }

            printDialog.Document.Print();
        }
    }
}