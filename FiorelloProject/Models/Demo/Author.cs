using System;
namespace FiorelloProject.Models.Demo
{
	public class Author
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public int SosialPageId { get; set; }
        public SosialPage SosialPage { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }

    }
}

