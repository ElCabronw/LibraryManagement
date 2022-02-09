using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryManagement.Models.Base;

namespace LibraryManagement.Models
{
    [Table("genre")]
    public class Genre : BaseEntity
	{
        [Column("name")]
        [Required]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}

