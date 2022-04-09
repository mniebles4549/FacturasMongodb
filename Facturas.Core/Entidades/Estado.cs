using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturas.Core
{
    public class Estado
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdEstado { get; set; }
        public string Nombre { get; set; }
    }
}
