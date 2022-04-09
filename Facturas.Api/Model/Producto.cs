using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Facturas.Api.Model
{
    public class Producto
    {
        [BsonId]
        public ObjectId IdProdcuto { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }
}
