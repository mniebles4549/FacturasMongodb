using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Facturas.Core
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public int Nit { get; set; }
        public int Estado { get; set; }
    }
}
