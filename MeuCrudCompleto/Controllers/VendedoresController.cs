using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuCrudCompleto.Servicos;
using MeuCrudCompleto.Data;

namespace MeuCrudCompleto.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorServico _vendedorServico;
        public VendedoresController(VendedorServico vendedorServico)
        {
            _vendedorServico = vendedorServico;
        }

        public IActionResult Index()
        {
            var list = _vendedorServico.FindAll();
            return View(list);
        }
    }
}
