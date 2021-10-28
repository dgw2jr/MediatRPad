using System.Globalization;
using System.Resources;

namespace MediatRPad
{
    public interface ILocalizer
    {
        string Localize(string name);
    }

    public class Localizer : ILocalizer
    {
        private readonly ResourceManager _resourceManager;

        public Localizer(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public string Localize(string name)
        {
            return _resourceManager.GetString(name, CultureInfo.CurrentCulture);
        }
    }
}
