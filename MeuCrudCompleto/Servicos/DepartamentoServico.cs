using MeuCrudCompleto.Data;
using MeuCrudCompleto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace MeuCrudCompleto.Servicos
{
    public class DepartamentoServico
    {
        private readonly MeuCrudCompletoContext _context;
            public DepartamentoServico(MeuCrudCompletoContext context)
        {
            _context = context;
        }
        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.nome).ToListAsync();
        }

      
    }
}
