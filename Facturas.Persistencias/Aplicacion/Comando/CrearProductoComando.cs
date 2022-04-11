using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturas.Aplicacion
{
  public  class CrearProductoComando : IRequest
    {
            public string IdProducto { get; set; }
            public string Nombre { get; set; }
            public double Precio { get; set; }
    }
}
