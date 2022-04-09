using Facturas.Core;
using FluentValidation;
using MediatR;
using MongoDB.Bson;
using System.Threading;
using System.Threading.Tasks;

namespace Facturas.Infraestructura
{
    public class NuevoProducto
    {

        public class Ejecuta : IRequest
        {
            public string IdProducto { get; set; }
            public string Nombre { get; set; }
            public double Precio { get; set; }

        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta> { }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly IClienteCollection _clienteCollection;

            public Manejador(IClienteCollection clienteCollection)
            {
                _clienteCollection = clienteCollection;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
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
}
