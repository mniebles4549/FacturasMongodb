using Facturas.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Facturas.Aplicacion.Aplicacion.Resolver.ComandoResolver
{
    public class CrearDetalleResolver : IRequestHandler<CrearDetalleComando>
    {

        private readonly ISaveCollection _clienteCollection;

        public CrearDetalleResolver(ISaveCollection clienteCollection)
        {
            _clienteCollection = clienteCollection;
        }

        public async Task<Unit> Handle(CrearDetalleComando request, CancellationToken cancellationToken)
        {
            var nuevoDetalle = new Detalle
            {
                IdDetalle = request.IdDetalle,
                IdFactura = request.IdFactura,
                IdProducto = request.IdProducto,
                Cantidad = request.Cantidad,
                precio = request.precio
            };
            await _clienteCollection.NuevaDetalle(nuevoDetalle);
            return Unit.Value;
        }
    }
}


