using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MediatRPad.Controls
{
    public sealed class TopToolStrip : ToolStrip, IMainFormComponent
    {
        public TopToolStrip(IEnumerable<IMenuConfiguration> menuConfigurations)
        {
            Dock = DockStyle.Fill;

            foreach (var menuConfiguration in menuConfigurations.OrderBy(c => c.Order))
            {
                var m = new ToolStripMenuItem
                {
                    Text = menuConfiguration.Text
                };

                m.DropDownItems.AddRange(menuConfiguration.Options
                    .OrderBy(o => o.Order)
                    .Select(c =>
                    {
                        var item = new ToolStripMenuItem(c.Text);
                        item.Click += c.Click;
                        return item;
                    }).ToArray());

                Items.Add(m);
            }
        }
    }
}