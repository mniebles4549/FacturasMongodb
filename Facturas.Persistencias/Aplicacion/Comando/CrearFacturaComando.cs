using MediatR;
using System;

namespace Facturas.Aplicacion
{
    public class CrearFacturaComando : IRequest
    {
        public string IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string IdCliente { get; set; }

        public int Iva { get; set; }

        public double TotalApagar { get; set; }

        public bool Pagado { get; set; }
        public CrearFacturaComando()
        { 
            Fecha = DateTime.Now;
        }

    }



}

