using Facturas.Core;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Facturas.Infraestructura
{
    public class ClienteCollection : IClienteCollection
    {
        //internal MongoDBRepositorio _mongoDBRepositorio = new MongoDBRepositorio();
        private readonly IMongoCollection<Cliente> _collectionCliente;
        private readonly IMongoCollection<Factura> _collectionFactura;
        private readonly IMongoCollection<Detalle> _collectionDetalle;
        private readonly IMongoCollection<Producto> _collectionProducto;
        //private readonly IMongoCollection<Estado> _collectionEstado;
        //public ClienteCollection()
        //{
        //    try
        //    {
        //        _collectionCliente = _mongoDBRepositorio.db.GetCollection<Cliente>("Clientes");
        //        _collectionFactura = _mongoDBRepositorio.db.GetCollection<Factura>("Facturas");
        //        _collectionDetalle = _mongoDBRepositorio.db.GetCollection<Detalle>("Detalles");
        //        _collectionProducto = _mongoDBRepositorio.db.GetCollection<Producto>("Productos");
        //        //_collectionEstado = _mongoDBRepositorio.db.GetCollection<Estado>("Estados");

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public ClienteCollection(IMongoClient client)
        {
            var database = client.GetDatabase("Facturas");
            var collection = database.GetCollection<Cliente>(nameof(Cliente));
            var collectionp = database.GetCollection<Producto>(nameof(Producto));
            var collectionf = database.GetCollection<Factura>(nameof(Factura));
            var collectiond = database.GetCollection<Detalle>(nameof(Detalle));
            _collectionDetalle = collectiond;
            _collectionCliente = collection;
            _collectionProducto = collectionp;
            _collectionFactura = collectionf;
        }
        //public async Task<List<Factura>> GetAll()
        //{

        //    try
        //    {
        //        var respuesta = await _collectionFactura.Find(new BsonDocument()).ToListAsync();
        //        if (respuesta.Count == 0)
        //        {

        //            var listaEstados = new List<Estado>();


        //            var listaClientes = new List<Cliente>();
        //            listaClientes.Add(new Cliente
        //            {
        //                IdCliente = "000000000000000000000001",
        //                Ciudad = "Barranquilla",
        //                Nombre = "Michel Niebles",
        //                Nit = 101,
        //                Estado = 1

        //            });
        //            listaClientes.Add(new Cliente
        //            {
        //                IdCliente = "000000000000000000000002",
        //                Ciudad = "Bogota",
        //                Nombre = "Jose Canseco",
        //                Nit = 101,
        //                Estado = 1

        //            });
        //            listaClientes.Add(new Cliente
        //            {
        //                IdCliente = "000000000000000000000003",
        //                Ciudad = "Medellin",
        //                Nombre = "Andrea Martinez",
        //                Nit = 101,
        //                Estado = 1

        //            });
        //            foreach (var cliente in listaClientes)
        //            {
        //                await _collectionCliente.InsertOneAsync(cliente);
        //            }


        //            var listaFacturas = new List<Factura>();
        //            listaFacturas.Add(new Factura()
        //            {
        //                IdFactura = "000000000000000000000001",
        //                Fecha = DateTime.Now.Date,
        //                IdCliente = "000000000000000000000001",
        //                Iva = 7600,
        //                TotalApagar = 47600,
        //                Pagado = false

        //            });
        //            listaFacturas.Add(new Factura()
        //            {
        //                IdFactura = "000000000000000000000002",
        //                Fecha = DateTime.Now.Date,
        //                IdCliente = "000000000000000000000002",
        //                Iva = 7600,
        //                TotalApagar = 47600,
        //                Pagado = false

        //            });
        //            listaFacturas.Add(new Factura()
        //            {
        //                IdFactura = "000000000000000000000003",
        //                Fecha = DateTime.Now.Date,
        //                IdCliente = "000000000000000000000003",
        //                Iva = 7600,
        //                TotalApagar = 47600,
        //                Pagado = false

        //            });
        //            foreach (var factura in listaFacturas)
        //            {
        //                await _collectionFactura.InsertOneAsync(factura);
        //            }



        //            var producto = new Producto()
        //            {
        //                Nombre = "Mango",
        //                Precio = 2000

        //            };
        //            await _collectionProducto.InsertOneAsync(producto);

        //            var listProducto = new List<Producto>();
        //            listProducto.Add(producto);

        //            var listaDetalles = new List<Detalle>();
        //            listaDetalles.Add(new Detalle
        //            {
        //                IdFactura = "000000000000000000000001",
        //                Prodcuto = listProducto,
        //                Cantidad = 20,
        //                precio = producto.Precio * 20
        //            });
        //            listaDetalles.Add(new Detalle
        //            {
        //                IdFactura = "000000000000000000000002",
        //                Prodcuto = listProducto,
        //                Cantidad = 20,
        //                precio = producto.Precio * 20
        //            });
        //            listaDetalles.Add(new Detalle
        //            {
        //                IdFactura = "000000000000000000000003",
        //                Prodcuto = listProducto,
        //                Cantidad = 20,
        //                precio = producto.Precio * 20
        //            });
        //            foreach (var detalle in listaDetalles)
        //            {
        //                await _collectionDetalle.InsertOneAsync(detalle);
        //            }

        //        }


        //        return respuesta;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

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

        public async Task NuevoCliente(Cliente cliente)
        {
            await _collectionCliente.InsertOneAsync(cliente);
        }
        public async Task NuevoProducto(Producto producto)
        {
            await _collectionProducto.InsertOneAsync(producto);
        }
        public async Task NuevaFactura(Factura factura)
        {
            await _collectionFactura.InsertOneAsync(factura);
        }
        public async Task NuevaDetalle(Detalle detalle)
        {
            await _collectionDetalle.InsertOneAsync(detalle);
        }
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
