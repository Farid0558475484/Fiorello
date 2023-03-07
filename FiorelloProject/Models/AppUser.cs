using System;
using Microsoft.AspNetCore.Identity;

namespace FiorelloProject.Models
{
	public class AppUser:IdentityUser
	{
		public string Fulname { get; set; }

	}
}

