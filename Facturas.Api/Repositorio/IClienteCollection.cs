using Facturas.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturas.Api.Repositorio
{
   public interface IClienteCollection
    {
      Task<List<Factura>> GetAll();
        Task<string> GetEstadoCliente(string clienteId);
    }
}
