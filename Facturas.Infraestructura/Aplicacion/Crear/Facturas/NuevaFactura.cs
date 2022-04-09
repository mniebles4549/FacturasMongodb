using Facturas.Core;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Facturas.Infraestructura
{
    public class NuevaFactura
    {

        public class Ejecuta : IRequest
        {
            public string IdFactura { get; set; }
            public DateTime Fecha { get; set; }
            public string IdCliente { get; set; }

            public int Iva { get; set; }

            public double TotalApagar { get; set; }

            public bool Pagado { get; set; }

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
}
