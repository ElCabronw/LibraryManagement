using System;
using AutoMapper;
using LibraryManagement.Data.DTOs;
using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using LibraryManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repository
{
	public class AuthorRepository : IAuthorRepository
	{
		private readonly MyPostgreSQLContext _context;
		private IMapper _mapper;
		public AuthorRepository(MyPostgreSQLContext context, IMapper mapper)
        {
			_context = context;
		}

        public async Task<IEnumerable<AuthorDTO>> FindAll()
        {
            try
            {
                var authors = await _context.Authors.ToListAsync();
                return _mapper.Map<List<AuthorDTO>>(authors);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<AuthorDTO> FindById(long id)
        {
            try
            {
                Author author = await _context.Authors.FindAsync(id);
                return _mapper.Map<AuthorDTO>(author);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<AuthorDTO> Create(AuthorDTO vo)
        {
            try
            {
                Author author = _mapper.Map<Author>(vo);
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                return _mapper.Map<AuthorDTO>(author);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<AuthorDTO> Update(AuthorDTO vo)
        {
            try
            {
                Author author = _mapper.Map<Author>(vo);
                _context.Authors.Update(author);
                await _context.SaveChangesAsync();
                return _mapper.Map<AuthorDTO>(author);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                Author author = await _context.Authors.FindAsync(id);
                if (author == null)
                {
                    return false;
                }
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

