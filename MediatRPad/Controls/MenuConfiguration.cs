using MediatRPad.Properties;
using MediatRPad;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;

namespace MediatRPad.Controls
{
    public interface IMenuConfiguration
    {
        IEnumerable<ButtonConfiguration> Options { get; }
        int Order { get; }
        string Text { get; }
        string Name { get; }
    }

    public abstract class MenuConfiguration : IMenuConfiguration
    {
        private readonly ILocalizer _localizer;

        public MenuConfiguration(IEnumerable<ButtonConfiguration> buttonConfigurations, ILocalizer localizer)
        {
            Options = buttonConfigurations.Where(c => c.ParentMenuName == Name);
            _localizer = localizer;
        }

        public string Text => _localizer.Localize(Name) ?? Name;
        public int Order { get; protected set; }
        public IEnumerable<ButtonConfiguration> Options { get; }
        public string Name { get; protected set; }
    }

    public class FileMenu : MenuConfiguration, IMainFormComponent
    {
        public FileMenu(IEnumerable<ButtonConfiguration> buttonConfigurations, ILocalizer localizer) : base(buttonConfigurations, localizer)
        {
            Name = MenuConstants.Names.File;
            Order = 0;
        }
    }

    public class HelpMenu : MenuConfiguration, IMainFormComponent
    {
        public HelpMenu(IEnumerable<ButtonConfiguration> buttonConfigurations, ILocalizer localizer) : base(buttonConfigurations, localizer)
        {
            Name = MenuConstants.Names.Help;
            Order = 1;
        }
    }

    public class CultureMenu : MenuConfiguration, IMainFormComponent
    {
        public CultureMenu(IEnumerable<ButtonConfiguration> buttonConfigurations, ILocalizer localizer) : base(buttonConfigurations, localizer)
        {
            Name = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            Order = 2;
        }
    }
}