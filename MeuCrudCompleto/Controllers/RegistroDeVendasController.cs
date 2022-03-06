using MeuCrudCompleto.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuCrudCompleto.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        private readonly RegistroDeVendasServico _registroDeVendasServico;

        public RegistroDeVendasController(RegistroDeVendasServico registroDeVendasServico)
        {
            _registroDeVendasServico = registroDeVendasServico;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _registroDeVendasServico.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

       
    }
}