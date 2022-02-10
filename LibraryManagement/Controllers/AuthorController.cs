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
        /// <summary>
        /// Obtém uma lista de autores
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Author            
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Retorna a lista de autores.</returns>
        /// <response code="200">Retorna a lista de autores</response>
        /// <response code="400">Erro na consulta.</response>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> FindAll()
        {
            try
            {
                var authors = await _repository.FindAll();
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro inesperado. Mensagem : {ex.Message} \r\n Detalhes : {ex.StackTrace}");
            }
          
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
        ///Cria um autor
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Author
        ///     {
        ///        "firstName": "Fulano",
        ///        "lastName": " da Silva ",
        ///     }
        ///
        /// </remarks>
        /// <param name="vo"></param>
        /// <returns>Retorna o objeto do autor criado</returns>
        /// <response code="200">Retorna o autor criado</response>
        /// <response code="400">Erro ao criar o autor.</response>
        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> Create([FromBody] AuthorDTO vo)
        {
            try
            {
                if (vo == null) return BadRequest();
                var author = await _repository.Create(vo);
                return Ok(author);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro inesperado. Mensagem : {ex.Message} \r\n Detalhes : {ex.StackTrace}");
            }
        
        }
        /// <summary>
        ///Atualiza um autor
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Author
        ///     {
        ///        "id": 1
        ///        "firstName": "Fulano",
        ///        "lastName": " da Silva ",
        ///     }
        ///
        /// </remarks>
        /// <param name="vo"></param>
        /// <returns>Retorna o objeto do autor atualizado</returns>
        /// <response code="200">Retorna o autor atualizado</response>
        /// <response code="400">Erro ao atualizar o autor.</response>
        [HttpPut]
        public async Task<ActionResult<AuthorDTO>> Update([FromBody] AuthorDTO vo)
        {
            try
            {
                if (vo == null) return BadRequest();
                var author = await _repository.Update(vo);
                return Ok(author);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro inesperado. Mensagem : {ex.Message} \r\n Detalhes : {ex.StackTrace}");
            }
         

        }
        /// <summary>
        /// Apaga um autor pelo Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /Author/1            
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
                else return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro inesperado. Mensagem : {ex.Message} \r\n Detalhes : {ex.StackTrace}");
            }
        
        }
    }
}

