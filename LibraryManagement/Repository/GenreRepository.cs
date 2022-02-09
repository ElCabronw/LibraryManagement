using System;
using AutoMapper;
using LibraryManagement.Data.DTOs;
using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using LibraryManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repository
{
	public class GenreRepository : IGenreRepository
	{
		private readonly MyPostgreSQLContext _context;
		private IMapper _mapper;
		public GenreRepository(MyPostgreSQLContext context, IMapper mapper) 
        {
			_context = context;
			_mapper = mapper;
		}
        public async Task<IEnumerable<GenreDTO>> FindAll()
        {
            try
            {
                var genres = await _context.Genres.ToListAsync();
                return _mapper.Map<List<GenreDTO>>(genres);
            }
            catch (Exception ex)
            {
                throw ex;
            }
       
        }
        public async Task<GenreDTO> FindById(long id)
        {
            try
            {
                Genre genre = await _context.Genres.FindAsync(id);
                return _mapper.Map<GenreDTO>(genre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }
        public async Task<GenreDTO> Create(GenreDTO vo)
        {
            try
            {
                Genre genre = _mapper.Map<Genre>(vo);
                _context.Genres.Add(genre);
                await _context.SaveChangesAsync();
                return _mapper.Map<GenreDTO>(genre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<GenreDTO> Update(GenreDTO vo)
        {
            try
            {
                Genre genre = _mapper.Map<Genre>(vo);
                _context.Genres.Update(genre);
                await _context.SaveChangesAsync();
                return _mapper.Map<GenreDTO>(genre);
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
                Genre genre = await _context.Genres.FindAsync(id);
                if (genre == null)
                {
                    return false;
                }
                _context.Genres.Remove(genre);
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

