using Facturas.Api.Model;
using Facturas.Api.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
      private  IClienteCollection db = new ClienteCollection();

        [HttpGet]
        public async Task<ActionResult<List<Factura>>> GetAll()
        {
          return await db.GetAll();
        }
        [HttpGet("{clienteId}")]
        public async Task<ActionResult<string>> GetEstadoCliente(string clienteId)
        {
            return await db.GetEstadoCliente(clienteId);
        }
    }
}
