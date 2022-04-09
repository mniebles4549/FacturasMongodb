using Facturas.Infraestructura;
using MediatR;
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
    public class ProductosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductosController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Crear()
        {
            var producto = new NuevoProducto.Ejecuta()
            {
                IdProducto = "000000000000000000000001",
                Nombre = "Mango",
                Precio = 2000
            };
            await _mediator.Send(producto);
            return Ok();
        }
    }
}
