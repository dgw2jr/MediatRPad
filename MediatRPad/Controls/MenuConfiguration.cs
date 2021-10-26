using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatRPad.Controls
{
    public interface IMenuConfiguration
    {
        IEnumerable<ButtonConfiguration> Options { get; }
        int Order { get; }
        string Text { get; }
    }

    public abstract class MenuConfiguration : IMenuConfiguration
    {
        public MenuConfiguration(IEnumerable<ButtonConfiguration> buttonConfigurations)
        {
            Options = buttonConfigurations.Where(c => c.ParentMenuName == Text);
        }

        public string Text { get; protected set; }
        public int Order { get; protected set; }
        public IEnumerable<ButtonConfiguration> Options { get; }
    }

    public class FileMenu : MenuConfiguration, IMainFormComponent
    {
        public FileMenu(IEnumerable<ButtonConfiguration> buttonConfigurations) : base(buttonConfigurations) 
        {
            Text = "File";
            Order = 0;
        }
    }

    public class HelpMenu : MenuConfiguration, IMainFormComponent
    {
        public HelpMenu(IEnumerable<ButtonConfiguration> buttonConfigurations) : base(buttonConfigurations)
        {
            Text = "Help";
            Order = 1;
        }
    }
}