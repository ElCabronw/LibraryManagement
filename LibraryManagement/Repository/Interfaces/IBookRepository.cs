using System;
using LibraryManagement.Data.DTOs;

namespace LibraryManagement.Repository.Interfaces
{
	public interface IBookRepository
	{
		Task<IEnumerable<BookDTO>> FindAll(bool sortByName = false);
		Task<BookDTO> FindById(long id);
		Task<BookInclusaoDTO> Create(BookInclusaoDTO vo);
		Task<BookDTO> Update(BookDTO vo);
		Task<bool> Delete(long id);
	}
}

