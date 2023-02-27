using System;
namespace FiorelloProject.Models.Demo
{
	public class BookAuthor
	{
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}

