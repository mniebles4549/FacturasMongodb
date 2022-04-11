using Facturas.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Facturas.Aplicacion.Aplicacion.Resolver.ComandoResolver
{
    public class CrearProductoResolver : IRequestHandler<CrearProductoComando>
    {

        private readonly ISaveCollection _clienteCollection;

        public CrearProductoResolver(ISaveCollection clienteCollection)
        {
            _clienteCollection = clienteCollection;
        }

        public async Task<Unit> Handle(CrearProductoComando request, CancellationToken cancellationToken)
        {
            var nuevoProducto = new Producto
            {
                IdProducto = request.IdProducto,
                Nombre = request.Nombre,
                Precio = request.Precio
            };
            await _clienteCollection.NuevoProducto(nuevoProducto);
            return Unit.Value;
        }
    }
}
