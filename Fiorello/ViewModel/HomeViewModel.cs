using Fiorello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello.ViewModel
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }

        public List<Category> Categories { get; set; }

        public List<Product> Products { get; set; }

        public Sliderintro Sliderintro { get; set; }

        public AboutMain AboutMain { get; set; }

        public List<AboutIcon> AboutIcon { get; set; }

        public ExspertTitle ExspertTitle { get; set; }

        public List<Exsperts> Exsperts { get; set; }

        public BlogTitle BlogTitle { get; set; }

        public List<BlogMain> Blogs { get; set; }

        public List<Say> Says { get; set; }
    }
}
