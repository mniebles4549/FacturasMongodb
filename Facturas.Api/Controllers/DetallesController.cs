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
    public class DetallesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DetallesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Crear()
        {
            var listaDetalles = new List<NuevoDetalle.Ejecuta>();
            listaDetalles.Add(new NuevoDetalle.Ejecuta
            {
                IdFactura = "000000000000000000000001",
                IdProducto = "000000000000000000000001",
                Cantidad = 20,
                precio = 2000 * 20
            });
            listaDetalles.Add(new NuevoDetalle.Ejecuta
            {
                IdFactura = "000000000000000000000002",
                IdProducto = "000000000000000000000001",
                Cantidad = 20,
                precio = 2000 * 20
            });
            listaDetalles.Add(new NuevoDetalle.Ejecuta
            {
                IdFactura = "000000000000000000000003",
                IdProducto = "000000000000000000000001",
                Cantidad = 20,
                precio = 2000 * 20
            });
            foreach (var detalle in listaDetalles)
            {
                await _mediator.Send(detalle);
            }
            return Ok();
        }
      
    }
}
