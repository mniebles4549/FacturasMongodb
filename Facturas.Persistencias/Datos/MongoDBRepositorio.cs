using MongoDB.Driver;


namespace Facturas.Persistencias
{
    public class MongoDBRepositorio
    {
        private readonly MongoClient cliente;
        private readonly IMongoDatabase db;
        public MongoDBRepositorio()
        {
            cliente = new MongoClient("mongodb://127.0.0.1:27017");
            db = cliente.GetDatabase("Facturas");
        }
    }
}
