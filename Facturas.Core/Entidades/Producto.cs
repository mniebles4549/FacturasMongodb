using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Facturas.Core
{
    public class Producto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdProducto { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }
}
