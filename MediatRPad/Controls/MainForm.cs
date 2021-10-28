using System.Drawing;
using System.Resources;
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
            Text = new ResourceManager(typeof(Resources)).GetString("AppTitle");
        }
    }
}
