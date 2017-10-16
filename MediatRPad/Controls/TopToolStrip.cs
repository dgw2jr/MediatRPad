using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MediatRPad.Controls
{
    public sealed class TopToolStrip : ToolStrip, IMainFormComponent
    {
        public TopToolStrip(IEnumerable<ButtonConfiguration> buttonConfigs)
        {
            Dock = DockStyle.Fill;

            foreach (var button in buttonConfigs.OrderBy(bc => bc.Order))
            {
                var b = new ToolStripButton(button.Text);
                b.Click += button.Click;
                Items.Add(b);
            }
        }
    }
}