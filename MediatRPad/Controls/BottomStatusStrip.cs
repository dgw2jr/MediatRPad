using System.Windows.Forms;

namespace MediatRPad.Controls
{
    public sealed class BottomStatusStrip : StatusStrip, IMainFormComponent
    {
        public BottomStatusStrip(BottomStatusStripLabel label)
        {
            Items.Add(label);
        }
    }
}