﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MeuCrudCompleto.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Email { get; set; }
        public DateTime DataAniversario { get; set; }
        public double BaseSalario { get; set; }

        public Departamento Departamento { get; set; }
        public ICollection<RegistroDeVendas> Vendas { get; set; } = new List<RegistroDeVendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime dataAniversario, double baseSalario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            this.Email = email;
            DataAniversario = dataAniversario;
            BaseSalario = baseSalario;
            Departamento = departamento;
        }
        public void AddVendas(RegistroDeVendas sr)
        {
            Vendas.Add(sr);
        }
        public void RemoveVendas(RegistroDeVendas sr)
        {
            Vendas.Remove(sr);
        }
        public double TotalVendas(DateTime initial, DateTime final)
        {
            return Vendas.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Montante);
        }
    }
}
