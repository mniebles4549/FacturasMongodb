using Facturas.Core;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Facturas.Infraestructura
{
    public class NuevoCliente
    {

        public class Ejecuta : IRequest
        {
            public string IdCliente { get; set; }
            public string Nombre { get; set; }
            public string Ciudad { get; set; }
            public int Nit { get; set; }
            public int Estado { get; set; }
         
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta> {}

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly IClienteCollection _clienteCollection;

            public Manejador(IClienteCollection clienteCollection)
            {
                _clienteCollection = clienteCollection;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {              
               var nuevoCliente =  new Cliente
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
}
