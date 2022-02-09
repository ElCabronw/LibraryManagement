using System;
using LibraryManagement.Data.DTOs;

namespace LibraryManagement.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        Task<AuthorDTO> Create(AuthorDTO vo);
        Task<bool> Delete(long id);
        Task<IEnumerable<AuthorDTO>> FindAll();
        Task<AuthorDTO> FindById(long id);
        Task<AuthorDTO> Update(AuthorDTO vo);
    }
}

