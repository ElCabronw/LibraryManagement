using System;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models.Context
{
	public class MyPostgreSQLContext : DbContext
	{
        public MyPostgreSQLContext(){}

		public MyPostgreSQLContext(DbContextOptions<MyPostgreSQLContext> options) : base(options) { }

		public DbSet<Author> Authors { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Logger> Loggers { get; set; }


		//Seed Data
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Seed Authors
			modelBuilder.Entity<Author>().HasData(new Author
			{
				Id = 1,
				FirstName = "Machado",
				LastName = "de Assis"
			});
			modelBuilder.Entity<Author>().HasData(new Author
			{
				Id = 2,
				FirstName = "Joanne",
				LastName = "Rowling"
			});
			modelBuilder.Entity<Author>().HasData(new Author
			{
				Id = 3,
				FirstName = "Clarice",
				LastName = "Lispector"
			});

			//Seed Genres
			modelBuilder.Entity<Genre>().HasData(new Genre
			{
				Id = 1,
				Name = "Romance",
			});
			modelBuilder.Entity<Genre>().HasData(new Genre
			{
				Id = 2,
				Name = "Science Fiction",
			});
			modelBuilder.Entity<Genre>().HasData(new Genre
			{
				Id = 3,
				Name = "Fantasy",
			});

			//Seed Books
			modelBuilder.Entity<Book>().HasData(new Book
			{
				Id = 1,
				Name = "Harry Potter e a Pedra filosofal",
				GenreId = 3,
				AuthorId = 2
			});
			modelBuilder.Entity<Book>().HasData(new Book
			{
				Id = 2,
				Name = "O Alienista",
				GenreId = 2,
				AuthorId = 1
			});
			modelBuilder.Entity<Book>().HasData(new Book
			{
				Id = 3,
				Name = "A Hora da Estrela",
				GenreId = 1,
				AuthorId = 3
			});

		}
	}
}

