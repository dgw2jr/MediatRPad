using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesCoreTest.Data
{
    public class CarouselViewModel
    {
        public List<CarouselPaneViewModel> CarouselPaneViewModels { get; set; }
        public int DefaultPaneId { get; set; }
    }

    public class CarouselPaneViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public string ImageAltText { get; set; }
    }
}
