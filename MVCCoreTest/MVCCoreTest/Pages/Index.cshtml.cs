using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCoreTest.Data;

namespace MVCCoreTest.Pages
{
    public class IndexModel : PageModel
    {
        public CarouselViewModel CarouselViewModel { get; set; }

        public void OnGet()
        {
            CarouselViewModel = new CarouselViewModel
            {
                DefaultPaneId = 1,
                CarouselPaneViewModels = new List<CarouselPaneViewModel>
                {
                    new CarouselPaneViewModel
                    {
                        Id = 1,
                        ImageAltText = "Test",
                        Text = "Blah blah"
                    }
                }
            };
        }
    }
}
