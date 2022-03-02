using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MeuCrudCompleto.Models;

namespace MeuCrudCompleto.Data
{
    public class MeuCrudCompletoContext : DbContext
    {
        public MeuCrudCompletoContext (DbContextOptions<MeuCrudCompletoContext> options)
            : base(options)
        {
        }

        public DbSet<MeuCrudCompleto.Models.Departamento> Departamento { get; set; }
    }
}
