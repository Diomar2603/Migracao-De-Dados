using ApiMigracaoDeDados.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiMigracaoDeDados.Controllers
{
    [ApiController]
    [Route("cnpj")]
    public class EmpresaController : Controller
    {

        private readonly EmpresasService _empresasService;

        public  EmpresaController(EmpresasService service)
        {
            _empresasService = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("{cnpj:length(14)}")]
        public async Task<ActionResult> Get(string cnpj)
        {
            var empresa = await _empresasService.GetEmpresa(cnpj);
            if (empresa == null)
            {
                var socio = await _empresasService.GetSocio(cnpj);
                if (socio != null)
                    return Ok(socio);
            }
            else
            {
                return Ok(empresa);
            }
            return NotFound();
        }
    }
}
