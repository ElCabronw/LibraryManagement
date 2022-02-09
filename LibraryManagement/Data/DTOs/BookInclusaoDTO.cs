using System;
namespace LibraryManagement.Data.DTOs
{
	public class BookInclusaoDTO
	{
        public string Name { get; set; }
        public long AuthorId { get; set; }
        public long GenreId { get; set; }
    }
}

