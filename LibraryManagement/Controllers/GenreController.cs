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
        /// <summary>
        /// Obtém uma lista de generos
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Genre            
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Retorna a lista de generos.</returns>
        /// <response code="200">Retorna a lista de generos</response>
        /// <response code="400">Erro na consulta.</response>
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
        /// <summary>
        /// Obtém um genero pelo Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Genre/1            
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Retorna o genero pelo Id informado.</returns>
        /// <response code="200">Retorna o genero pelo Id</response>
        /// <response code="400">Genero nao encontrado.</response>
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
        /// <summary>
        ///Cria um genero
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Genre
        ///     {
        ///        "name": "Mistery",
        ///     }
        ///
        /// </remarks>
        /// <param name="vo"></param>
        /// <returns>Retorna o objeto do genero criado</returns>
        /// <response code="200">Retorna o genero criado</response>
        /// <response code="400">Erro ao criar o genero.</response>
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
        /// <summary>
        ///Atualiza um genero
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Genre
        ///     {
        ///        "id": 1
        ///        "name": "Mistery",
        ///     }
        ///
        /// </remarks>
        /// <param name="vo"></param>
        /// <returns>Retorna o objeto do genero atualizado</returns>
        /// <response code="200">Retorna o genero atualizado</response>
        /// <response code="400">Erro ao atualizar o genero.</response>
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
        /// <summary>
        /// Apaga um genero pelo Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Genre/1            
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Retorna true se apagar com sucesso.</returns>
        /// <response code="200">Retorna true</response>
        /// <response code="400">Retorna false</response>

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

