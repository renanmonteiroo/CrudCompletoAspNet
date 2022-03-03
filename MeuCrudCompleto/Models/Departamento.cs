
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeuCrudCompleto.Models
{
    public class Departamento
    {
        public int id { get; set; }
        public string nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamento()
        {
        }

        public Departamento(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }
        public void AddVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }
        public double TotalVendas (DateTime initial, DateTime final)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVendas(initial, final));
        }
    }
}
