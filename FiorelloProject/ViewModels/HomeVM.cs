using System;
using FiorelloProject.Models;

namespace FiorelloProject.ViewModels
{
	public class HomeVM
	{
        public List<Slider>? Sliders { get; set; }
        public SliderDetail? SliderDetail { get; set; }


        public List<Category>? Categories { get; set; }
        public List<Product>? Products { get; set; }
    }
}

