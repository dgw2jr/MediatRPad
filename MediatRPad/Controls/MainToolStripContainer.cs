using System.Windows.Forms;

namespace MediatRPad.Controls
{
    public sealed class MainToolStripContainer : ToolStripContainer, IMainFormComponent
    {
        public MainToolStripContainer(FileContentsTextBox textBox,
            TopToolStrip topToolStrip)
        {
            Dock = DockStyle.Fill;
            TopToolStripPanel.Controls.Add(topToolStrip);
            ContentPanel.Controls.Add(textBox);
        }
    }
}