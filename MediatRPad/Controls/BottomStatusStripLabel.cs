using System.Windows.Forms;
using MediatRPad.Properties;

namespace MediatRPad.Controls
{
    public sealed class BottomStatusStripLabel : ToolStripStatusLabel, IMainFormComponent
    {
        public BottomStatusStripLabel()
        {
            ForeColor = Settings.Default.StatusBarLabelColor;
        }
    }
}