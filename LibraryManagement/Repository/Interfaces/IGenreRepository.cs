using System;
using LibraryManagement.Data.DTOs;

namespace LibraryManagement.Repository.Interfaces
{
	public interface IGenreRepository
	{
        Task<GenreDTO> Create(GenreDTO vo);
        Task<bool> Delete(long id);
        Task<IEnumerable<GenreDTO>> FindAll();
        Task<GenreDTO> FindById(long id);
        Task<GenreDTO> Update(GenreDTO vo);
    }
}

