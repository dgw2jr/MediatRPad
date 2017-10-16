using System.Drawing;
using System.Windows.Forms;
using MediatRPad.Properties;

namespace MediatRPad.Controls
{
    public sealed class MainForm : Form
    {
        public MainForm(MainToolStripContainer toolStripContainer)
        {
            Controls.Add(toolStripContainer);
            Size = new Size(600, 400);
            Text = Resources.AppTitle;
        }
    }
}
