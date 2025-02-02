﻿using System;
using FiorelloProject.Models.Demo;

namespace FiorelloProject.ViewModels
{
	public class BookCreateVM
	{
        public string? Name { get; set; }
        public List<int> GenreIds { get; set; }
        public List<int> AuthorIds { get; set; }
        public IFormFile[] Photos { get; set; }

    }
}

