using Facturas.Core;
using MediatR;

namespace Facturas.Aplicacion
{
    public class CrearClienteComando : IRequest
    {
            public string IdCliente { get; set; }
            public string Nombre { get; set; }
            public string Ciudad { get; set; }
            public int Nit { get; set; }
            public int Estado { get; set; }
    }
}
