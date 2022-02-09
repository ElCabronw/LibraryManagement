using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryManagement.Models.Base;

namespace LibraryManagement.Models
{
    [Table("book")]
	public class Book : BaseEntity
	{
        [Column("title")]
        [Required]
        public string Name { get; set; }
        [Column("author_id")]
        [ForeignKey("Author")]
        public long AuthorId { get; set; }
        [Column("genre_id")]
        [ForeignKey("Genre")]
        public long GenreId { get; set; }


        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}

