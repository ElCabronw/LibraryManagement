using System;
using System.Text;
using AutoMapper;
using Dapper;
using LibraryManagement.Data.DTOs;
using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using LibraryManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repository
{
	public class BookRepository : IBookRepository
	{
		private readonly MyPostgreSQLContext _context;
		private IMapper _mapper;
		public BookRepository(MyPostgreSQLContext context, IMapper mapper) 
        {
			_context = context;
			_mapper = mapper;
		}

        public async Task<IEnumerable<BookDTO>> FindAll(bool sortByName = false) // Se True, ordenar pelo nome dos livros
        {
            try
            {
                var books = sortByName ?
                    await _context.Books.Include(x => x.Author).Include(x => x.Genre).OrderBy(x => x.Name).ToListAsync() :
                    await _context.Books.Include(x => x.Author).Include(x => x.Genre).OrderBy(x => x.Id).ToListAsync();
                return _mapper.Map<List<BookDTO>>(books);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public async Task<BookDTO> FindById(long id)
        {
            try
            {
                Book book = await _context.Books
                    .Include(x => x.Author)
                    .Include(x => x.Genre)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                return _mapper.Map<BookDTO>(book);
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
        public async Task<BookDTO> Create(BookInclusaoDTO vo)
        {
            try
            {
                Book book = _mapper.Map<Book>(vo);
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                return _mapper.Map<BookDTO>(book);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public async Task<BookDTO> Update(BookDTO vo)
        {
            try
            {
                Book book = _mapper.Map<Book>(vo);
                _context.Books.Update(book);
                await _context.SaveChangesAsync();
                return _mapper.Map<BookDTO>(book);
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
                Book book =
               await _context.Books.Where(p => p.Id == id)
                   .FirstOrDefaultAsync();
                if (book == null) return false;
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

