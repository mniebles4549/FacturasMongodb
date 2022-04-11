using Facturas.Core;
using MongoDB.Driver;

namespace Facturas.Infraestructura
{
    public class Dbcontext
    {

        private readonly IMongoDatabase _db;

        public Dbcontext(IMongoClient client, string dbName)
        {
            _db = client.GetDatabase(dbName);
        }

        public IMongoCollection<Cliente> Clientes => _db.GetCollection<Cliente>("Clientes");
        public IMongoCollection<Producto> Productos => _db.GetCollection<Producto>("Productos");
        public IMongoCollection<Factura> Facturas => _db.GetCollection<Factura>("Facturas");
        public IMongoCollection<Detalle> Detalles => _db.GetCollection<Detalle>("Detalles");
    }
}
