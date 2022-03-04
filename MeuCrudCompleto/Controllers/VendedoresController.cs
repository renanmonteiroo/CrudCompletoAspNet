using MeuCrudCompleto.Data;
using MeuCrudCompleto.Models;
using MeuCrudCompleto.Models.ViewsModels;
using MeuCrudCompleto.Servicos;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace MeuCrudCompleto.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorServico _vendedorServico;
        private readonly DepartamentoServico _departamentoServico;
        public VendedoresController(VendedorServico vendedorServico, DepartamentoServico departamentoServico)
        {
            _vendedorServico = vendedorServico;
            _departamentoServico = departamentoServico;
        }

        public IActionResult Index()
        {
            var list = _vendedorServico.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            var departamentos = _departamentoServico.FindAll();
            var viewModel = new VendedorCadastroViewModel { Departamentos = departamentos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedorServico.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }
            var obj = _vendedorServico.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedorServico.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = _vendedorServico.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _vendedorServico.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            List<Departamento> departamentos = _departamentoServico.FindAll();
            VendedorCadastroViewModel viewModel = new VendedorCadastroViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try {
            _vendedorServico.Update(vendedor);
            return RedirectToAction(nameof(Index));
            }
            //super casting
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new {message = e.Message });
            }
         
        }
        public IActionResult Error (string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
