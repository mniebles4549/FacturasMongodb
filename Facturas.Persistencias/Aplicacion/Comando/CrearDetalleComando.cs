using Facturas.Core;
using MediatR;
using MongoDB.Bson;

namespace Facturas.Aplicacion
{
    public class CrearDetalleComando : IRequest
    {
        public ObjectId IdDetalle { get; set; }
        public string IdFactura { get; set; }
        public string IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double precio { get; set; }
    }
}
