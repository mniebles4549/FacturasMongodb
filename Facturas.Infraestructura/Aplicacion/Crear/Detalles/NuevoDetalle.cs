using Facturas.Core;
using FluentValidation;
using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facturas.Infraestructura
{
 public   class NuevoDetalle
    {

        public class Ejecuta : IRequest
        {
            public ObjectId IdDetalle { get; set; }
            public string IdFactura { get; set; }
            public string IdProducto { get; set; }
            public int Cantidad { get; set; }
            public double precio { get; set; }

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
}
