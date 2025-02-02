using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        // Inicia la URL
        [HttpGet("prueba")]

        // Metodo pulbico que se ejecutara si la url es llamada
        public string Get()
        {
            return "Hola Mundo";
        }
    }
}
