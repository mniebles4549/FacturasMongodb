using Facturas.Aplicacion;
using Facturas.Core;
using Facturas.Infraestructura;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Facturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Crear()
        {
            var listaClientes = new List<CrearClienteComando>();
            listaClientes.Add(new CrearClienteComando
            {
                IdCliente = "000000000000000000000001",Ciudad ="Barranquilla",Nombre = "Michel Niebles", Nit = 101,Estado = 1
            });
            listaClientes.Add(new CrearClienteComando
            {
                IdCliente = "000000000000000000000002",Ciudad ="Bogota",Nombre = "Jose Canseco",Nit = 102,Estado = 1
            });
            listaClientes.Add(new CrearClienteComando
            {
                IdCliente = "000000000000000000000003",Ciudad ="Medellin",Nombre = "Andrea Martinez",Nit = 103,Estado = 1
            });
            foreach (var cliente in listaClientes)
            {
                await _mediator.Send(cliente);
            }
            return Ok();
        }
       
        //private IClienteCollection db = new ClienteCollection();

        //[HttpGet]
        //public async Task<ActionResult<List<Factura>>> GetAll()
        //{
        //    return await db.GetAll();
        //}
        //[HttpGet("{clienteId}")]
        //public async Task<ActionResult<string>> GetEstadoCliente(string clienteId)
        //{
        //    return await db.GetEstadoCliente(clienteId);
        //}
    }
}
