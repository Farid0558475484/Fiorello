using System;
using System.ComponentModel.DataAnnotations;

namespace FiorelloProject.ViewModels

{
	public class SliderCreateVM
	{
        [Required(ErrorMessage ="Sekil yoxdu")]
        public IFormFile Photo { get; set; }
    }
}

