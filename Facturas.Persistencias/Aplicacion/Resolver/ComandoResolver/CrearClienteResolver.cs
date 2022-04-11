using Facturas.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Facturas.Aplicacion
{
    public class CrearClienteResolver : IRequestHandler<CrearClienteComando>
    {

        private readonly ISaveCollection _clienteCollection;

        public CrearClienteResolver(ISaveCollection clienteCollection)
        {
            _clienteCollection = clienteCollection;
        }

        public async Task<Unit> Handle(CrearClienteComando request, CancellationToken cancellationToken)
        {
            var nuevoCliente = new Cliente
            {
                IdCliente = request.IdCliente,
                Ciudad = request.Ciudad,
                Nombre = request.Nombre,
                Nit = request.Nit,
                Estado = request.Estado
            };
            await _clienteCollection.NuevoCliente(nuevoCliente);
            return Unit.Value;
        }
    }

}
