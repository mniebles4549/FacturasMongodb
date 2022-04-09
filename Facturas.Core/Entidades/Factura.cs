using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
namespace Facturas.Core
{
    public class Factura
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string IdCliente { get; set; }

        public int Iva { get; set; }

        public double TotalApagar { get; set; }

        public bool Pagado { get; set; }
    }
}
