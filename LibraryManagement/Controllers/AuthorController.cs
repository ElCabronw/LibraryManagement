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
    public class AuthorController : ControllerBase
    {
        private IAuthorRepository _repository;

        public AuthorController(IAuthorRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> FindAll()
        {
            var products = await _repository.FindAll();
            return Ok(products);
        }
        /// <summary>
        /// Obtém um autor pelo Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Author/1            
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Retorna o autor pelo Id informado.</returns>
        /// <response code="200">Retorna o autor pelo Id</response>
        /// <response code="400">Autor nao encontrado.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> FindById(long id)
        {
            var author = await _repository.FindById(id);
            if (author == null) return NotFound();

            return Ok(author);
        }
        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> Create([FromBody] AuthorDTO vo)
        {
            if (vo == null) return BadRequest();
            var product = await _repository.Create(vo);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<AuthorDTO>> Update([FromBody] AuthorDTO vo)
        {
            if (vo == null) return BadRequest();
            var product = await _repository.Update(vo);
            return Ok(product);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var isDeleted = await _repository.Delete(id);
            if (!isDeleted) return BadRequest();
            else return Ok();
        }
    }
}

