using System.Windows.Forms;

namespace MediatRPad.Controls
{
    public sealed class FileContentsTextBox : TextBox, IMainFormComponent
    {
        public FileContentsTextBox()
        {
            AcceptsReturn = true;
            Dock = DockStyle.Fill;
            ScrollBars = ScrollBars.Both;
            Multiline = true;
        }
    }
}