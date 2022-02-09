using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryManagement.Models.Base;

namespace LibraryManagement.Models
{
	[Table("author")]
	public class Author : BaseEntity
	{
        [Column("first_name")]
        [Required]
        public string FirstName { get; set; }
        [Column("last_name")]
        [Required]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}

