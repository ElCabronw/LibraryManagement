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
    public class GenreController : ControllerBase
    {
        private IGenreRepository _repository;

        public GenreController(IGenreRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> FindAll()
        {
            try
            {
                var genres = await _repository.FindAll();
                return Ok(genres);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro inesperado. Mensagem : {ex.Message} \r\n Detalhes : {ex.StackTrace}");
            }
           
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> FindById(long id)
        {
            try
            {
                var author = await _repository.FindById(id);
                if (author == null) return NotFound();

                return Ok(author);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro inesperado. Mensagem : {ex.Message} \r\n Detalhes : {ex.StackTrace}");
            }

        }
        [HttpPost]
        public async Task<ActionResult<GenreDTO>> Create([FromBody] GenreDTO vo)
        {
            try
            {
                if (vo == null) return BadRequest();
                var genre = await _repository.Create(vo);
                return Ok(genre);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro inesperado. Mensagem : {ex.Message} \r\n Detalhes : {ex.StackTrace}");
            }

        }

        [HttpPut]
        public async Task<ActionResult<GenreDTO>> Update([FromBody] GenreDTO vo)
        {
            try
            {
                if (vo == null) return BadRequest();
                var genre = await _repository.Update(vo);
                return Ok(genre);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro inesperado. Mensagem : {ex.Message} \r\n Detalhes : {ex.StackTrace}");
            }
          

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var isDeleted = await _repository.Delete(id);
                if (!isDeleted) return BadRequest();
                else return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro inesperado. Mensagem : {ex.Message} \r\n Detalhes : {ex.StackTrace}");
            }
            
        }
    }
}

