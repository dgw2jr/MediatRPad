using System.Drawing;
using System.Windows.Forms;

namespace MediatRPad.Controls
{
    public sealed class MainForm : Form
    {
        public MainForm(MainToolStripContainer toolStripContainer, ILocalizer localizer)
        {
            Controls.Add(toolStripContainer);
            Size = new Size(600, 400);
            Text = localizer.Localize("AppTitle");
        }
    }
}
