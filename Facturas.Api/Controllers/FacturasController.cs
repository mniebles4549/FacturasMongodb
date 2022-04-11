using Facturas.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Facturas.Infraestructura;
using Microsoft.AspNetCore.Http;
using Facturas.Aplicacion;

namespace Facturas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FacturasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Crear()
        {
            var listaFacturas = new List<CrearFacturaComando>();

            listaFacturas.Add(new CrearFacturaComando()
            {
                IdFactura = "000000000000000000000001",Fecha = DateTime.Now.Date,IdCliente = "000000000000000000000001",Iva = 7600,TotalApagar = 47600,Pagado = false

            });
            listaFacturas.Add(new CrearFacturaComando()
            {
                IdFactura = "000000000000000000000002",Fecha = DateTime.Now.Date, IdCliente = "000000000000000000000002",Iva = 7600,TotalApagar = 47600,  Pagado = false

            });
            listaFacturas.Add(new CrearFacturaComando()
            {
                IdFactura = "000000000000000000000003", Fecha = DateTime.Now.Date, IdCliente = "000000000000000000000003",Iva = 7600, TotalApagar = 47600, Pagado = false
            });
            foreach (var factura in listaFacturas)
            {
                await _mediator.Send(factura);
            }
            return Ok();
        }
    }
}
