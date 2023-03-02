using System;
using System.ComponentModel.DataAnnotations.Schema;




namespace FiorelloProject.Models

{
	public class Slider
	{
		public int Id { get; set; }
		public string? ImagreUrl { get; set; }
		[NotMapped]
		public IFormFile Photo { get; set; }
        //public string ImageUrl { get; internal set; }
    }
}

