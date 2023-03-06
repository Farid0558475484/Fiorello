using System;
using System.ComponentModel;

namespace FiorelloProject.ViewModels
{
	public class SliderUpdateVM

	{
		public string ImageUrl { get; set; }
		[DisplayName("Lorem")]
		public IFormFile Photo { get; set; }
	}
}

