using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Data.DTOs;
using LibraryManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    [Route("api/v1/[controller]")]
    public class BookController : ControllerBase
    {
        private IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        /// <summary>
        /// Obtém um livro pelo Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /book/1            
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Retorna o livro pelo Id informado.</returns>
        /// <response code="200">Retorna o livro pelo Id</response>
        /// <response code="400">Livro nao encontrado.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> FindById(long id)
        {
            var book = await _repository.FindById(id);
            if (book == null) return NotFound();

            return Ok(book);
        }
        /// <summary>
        /// Obtém todos os livros cadastrados no sistema
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /book/1            
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Retorna todos os livros.</returns>
        /// <response code="200">Retorna todos os livros</response>
        /// <response code="400">Sem livros cadastrados na base.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> FindAll(bool sortByName)
        {
            var books = await _repository.FindAll(sortByName);
            return Ok(books);
        }
        /// <summary>
        ///Cria um livro
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Book
        ///     {
        ///        "name": "Livro #1",
        ///        "authorId": 1,
        ///        "genreId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="vo"></param>
        /// <returns>Retorna o objeto do livro criado</returns>
        /// <response code="200">Retorna o livro criado</response>
        /// <response code="400">Erro ao criar o livro.</response>
        [HttpPost]
        public async Task<ActionResult<BookDTO>> Create([FromBody] BookInclusaoDTO vo)
        {
            if (vo == null) return BadRequest();
            var book = await _repository.Create(vo);
            return Ok(book);
        }

        [HttpPut]
        public async Task<ActionResult<BookDTO>> Update([FromBody] BookDTO vo)
        {
            if (vo == null) return BadRequest();
            var book = await _repository.Update(vo);
            return Ok(book);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var isDeleted = await _repository.Delete(id);
            if (!isDeleted) return BadRequest();
            else return Ok(isDeleted);
        }
    }
}

