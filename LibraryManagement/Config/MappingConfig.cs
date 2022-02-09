using System;
using AutoMapper;
using LibraryManagement.Data.DTOs;
using LibraryManagement.Models;

namespace LibraryManagement.Config
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config => {
				config.CreateMap<Book, BookDTO>()
				.ForMember(x => x.GenreName, opt =>
				opt.MapFrom(src =>
				src.Genre.Name))
				.ForMember(x => x.AuthorName, opt =>
				opt.MapFrom(src =>
				src.Author.FirstName + " " + src.Author.LastName))
				;

				config.CreateMap<BookDTO, Book>();
				config.CreateMap<BookInclusaoDTO, Book>().ReverseMap();
				config.CreateMap<Author, AuthorDTO>().ReverseMap();
				config.CreateMap<Genre, GenreDTO>().ReverseMap();
			});
			return mappingConfig;
		}
	}
}

