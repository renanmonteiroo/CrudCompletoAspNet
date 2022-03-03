using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuCrudCompleto.Data;
using MeuCrudCompleto.Models;

namespace MeuCrudCompleto.Servicos
{
    public class VendedorServico
    {
        private readonly MeuCrudCompletoContext _context;
        
        public VendedorServico(MeuCrudCompletoContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }
        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
