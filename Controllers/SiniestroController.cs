using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using test.mt.mediator.Components;

namespace test.mt.mediator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiniestroController : ControllerBase
    {
        private readonly IRequestClient<ISiniestroAltaMedica> _requestClient;

        public SiniestroController(IRequestClient<ISiniestroAltaMedica> requestClient)
        {
            _requestClient = requestClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _requestClient.GetResponse<ISiniestroAltaMedicaStatus>( new { SiniestroId = 12352, FechaAltaMedica = InVar.Timestamp });

            return Ok(response.Message.Status == 1 ? "Procesada" : "Fallo al generar alta médica");
            
        }
    }
}
