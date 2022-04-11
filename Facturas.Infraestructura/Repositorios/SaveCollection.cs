using Facturas.Core;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Facturas.Infraestructura
{
    public class SaveCollection : ISaveCollection
    {

        private readonly Dbcontext _dbcontext;
        public SaveCollection(Dbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
           
        public async Task NuevoCliente(Cliente cliente)
        {
            await _dbcontext.Clientes.InsertOneAsync(cliente);
        }
        public async Task NuevoProducto(Producto producto)
        {
            await _dbcontext.Productos.InsertOneAsync(producto);
        }
        public async Task NuevaFactura(Factura factura)
        {
            await _dbcontext.Facturas.InsertOneAsync(factura);
        }
        public async Task NuevaDetalle(Detalle detalle)
        {
            await _dbcontext.Detalles.InsertOneAsync(detalle);
        }




        //public async Task<string> GetEstadoCliente(string clienteId)
        //{
        //    var cliente = await _collectionCliente.FindAsync(
        //        new BsonDocument { { "_id", new ObjectId(clienteId) } }).Result.FirstAsync();
        //    int estadoActulizado = 0;
        //    string respuesta = string.Empty;
        //    if (cliente.Estado == 1)
        //    {
        //        respuesta = $"El estado del cliente {cliente.Nombre} ha pasado a segundo recordatorio";
        //        estadoActulizado = 2;
        //    }
        //    else if (cliente.Estado == 2)
        //    {
        //        respuesta = $"El cliente {cliente.Nombre} esta desactivado";
        //        estadoActulizado = 3;
        //    }
        //    else
        //    {
        //        respuesta = $"No se puede enviar el correo porque el cliente {cliente.Nombre} esta desactivado";
        //    }
        //    cliente.Estado = estadoActulizado;
        //    var update = Builders<Cliente>.Filter.Eq(s => s.IdCliente, clienteId);
        //    await _collectionCliente.ReplaceOneAsync(update, cliente);
        //    return respuesta;

        //}


    }
}



//var consulta = from _factura in CollectionFactura.AsQueryable()
//               join _cliente in CollectionCliente.AsQueryable()
//               on _factura.IdCliente equals _cliente.IdCliente
//               select new Cliente
//               {
//                   Nombre = ""
//               };
//var clientesfacturas = consulta.Tolist();


//try
//{
//    //var docs = await CollectionFactura.Aggregate()
//    //  .Lookup("Cliente", "IdCliente", "_id", "")
//    //  .As<BsonDocument>()
//    //  .ToListAsync();

//    //foreach (var doc in docs)
//    //{
//    //    doc.ToJson();
//    //    //foreach (var item in doc)
//    //    //{
//    //    //    //var clienteFactura = new Cliente()
//    //    //    //{
//    //    //    //    Ciudad = item.cli
//    //    //    //};
//    //    //}

//    //}




//    //var respuesta = await CollectionCliente.Find(new BsonDocument()).ToListAsync();

//    //if (respuesta.Count == 0)
//    //{
//    //var cliente = new Cliente()
//    //{
//    //    Ciudad = "Niebles",
//    //    Nombre = "Michel",
//    //    Nit = 0101

//    //};

//    //    await CollectionCliente.InsertOneAsync(cliente);
//    //}
//    var respuesta = await _CollectionFactura.Find(new BsonDocument()).ToListAsync();

//    var cliente = new Cliente()
//    {
//        Ciudad = "Niebles",
//        Nombre = "Michel",
//        Nit = 0101

//    };
//    var fac = _CollectionFactura.Find(new BsonDocument
//                { { "_id", new ObjectId("6250250ee67fba931645a605") } }).FirstAsync().Result;
//    fac.ClienteLista = new List<Cliente>();

//    fac.ClienteLista.Add(cliente);

//    var update = Builders<Factura>.Filter.Eq(s => s.IdFactura, fac.IdFactura);
//    await _CollectionFactura.ReplaceOneAsync(update, fac);
//    //var factura = new Factura()
//    //{

//    //    Fecha = DateTime.Now.Date,
//    //};
//    //await CollectionFactura.InsertOneAsync(factura);
//    return respuesta;
//}
//catch (Exception ex)
//{

//    throw;
//}




//Estados
//listaEstados.Add(new Estado
//{
//    IdEstado = "000000000000000000000001",
//    Nombre = "primerrecordatorio",


//});
//listaEstados.Add(new Estado
//{
//    IdEstado = "000000000000000000000002",
//    Nombre = "segundorecordatorio",


//});
//listaEstados.Add(new Estado
//{
//    IdEstado = "000000000000000000000003",
//    Nombre = "desactivado",

//});

//foreach (var estado in listaEstados)
//{
//    await _collectionEstado.InsertOneAsync(estado);
//}
