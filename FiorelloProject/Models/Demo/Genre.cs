﻿using System;
namespace FiorelloProject.Models.Demo
{
	public class Genre
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<BookGenre> BookGenres { get; set; }
    }
}

