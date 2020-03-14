using System.Net;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoAutores.Domain.Interfaces.Services.Autor;
using ProjetoAutores.Domain.ViewModel;

namespace ProjetoAutores.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        public readonly IAutorService _service;
        public AutoresController(IAutorService service)
        {
            _service = service;
        }

        [HttpGet("ListarAutoresComNomeFormatado")]
        public async Task<ActionResult> ListarAutoresComNomeFormatado()
        {
            try
            {
                return Ok(await _service.ListarAutoresComNomeFormatado());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] AutorViewModel autor)
        {
            try
            {
                return Ok(await _service.Adicionar(autor));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

