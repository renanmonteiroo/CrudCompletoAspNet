using MeuCrudCompleto.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuCrudCompleto.Models
{
    public class RegistroDeVendas
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Montante { get; set; }
        public StatusDeVendas status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroDeVendas()
        {
        }

        public RegistroDeVendas(int id, DateTime date, double montante, StatusDeVendas status, Vendedor vendedor)
        {
            Id = id;
            Date = date;
            Montante = montante;
            this.status = status;
            Vendedor = vendedor;
        }
    }
}
