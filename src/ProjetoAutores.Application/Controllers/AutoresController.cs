using System.Net;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoAutores.Domain.Interfaces.Services.Autor;

namespace ProjetoAutores.Application.Controllers
{
    [Route("ap/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        public readonly IAutorService _service;
        public AutoresController(IAutorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

