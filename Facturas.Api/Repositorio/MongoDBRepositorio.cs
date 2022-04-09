using MongoDB.Driver;
using System;

namespace Facturas.Api.Repositorio
{
    public class MongoDBRepositorio
    {
        public MongoClient cliente;
        public IMongoDatabase db;
        public MongoDBRepositorio()
        {
            try
            {
                cliente = new MongoClient("mongodb://127.0.0.1:27017");
                db = cliente.GetDatabase("Facturas");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
