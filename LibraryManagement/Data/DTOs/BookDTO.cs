using System;
namespace LibraryManagement.Data.DTOs
{
	public class BookDTO
	{
        public long Id { get; set; }
        public string Name { get; set; }
        public long AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string GenreName { get; set; }
        public long GenreId { get; set; }
    }
}

