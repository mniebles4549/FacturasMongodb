using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturas.Core
{
    public class Detalle
    {
        [BsonId]
        public ObjectId IdDetalle { get; set; }
        public string IdFactura { get; set; }
        public string IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double precio { get; set; }
    }
}
