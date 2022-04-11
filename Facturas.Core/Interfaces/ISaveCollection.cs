using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Facturas.Core
{
    public interface ISaveCollection
    {
        //Task<List<Factura>> GetAll();
        //Task<string> GetEstadoCliente(string clienteId);
        Task NuevoCliente(Cliente cliente);
        Task NuevoProducto(Producto producto);
        Task NuevaFactura(Factura factura);
         Task NuevaDetalle(Detalle detalle);

    }
}
