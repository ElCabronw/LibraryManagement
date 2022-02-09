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

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> FindById(long id)
        {
            var book = await _repository.FindById(id);
            if (book == null) return NotFound();

            return Ok(book);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> FindAll(bool sortByName)
        {
            var books = await _repository.FindAll(sortByName);
            return Ok(books);
        }

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

