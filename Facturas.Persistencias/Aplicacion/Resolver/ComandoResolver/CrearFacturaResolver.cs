using Facturas.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturas.Aplicacion
{
    public class CrearFacturaResolver : IRequestHandler<CrearFacturaComando>
    {

        private readonly ISaveCollection _clienteCollection;

        public CrearFacturaResolver(ISaveCollection clienteCollection)
        {
            _clienteCollection = clienteCollection;
        }

        public async Task<Unit> Handle(CrearFacturaComando request, CancellationToken cancellationToken)
        {
            var nuevaFactura = new Factura
            {
                IdCliente = request.IdCliente,
                IdFactura = request.IdFactura,
                Fecha = request.Fecha,
                Iva = request.Iva,
                TotalApagar = request.TotalApagar,
                Pagado = request.Pagado
            };
            await _clienteCollection.NuevaFactura(nuevaFactura);
            return Unit.Value;
        }
    }
    }
