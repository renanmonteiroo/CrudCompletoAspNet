﻿using MeuCrudCompleto.Data;
using MeuCrudCompleto.Models;
using MeuCrudCompleto.Models.ViewsModels;
using MeuCrudCompleto.Servicos;
using MeuCrudCompleto.Servicos.Exceptions;
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

        public async Task<IActionResult> Index()
        {
            var list = await _vendedorServico.FindAllAsync();
            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            var departamentos = await _departamentoServico.FindAllAsync();
            var viewModel = new VendedorCadastroViewModel { Departamentos = departamentos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoServico.FindAllAsync();
                var viewModel = new VendedorCadastroViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }

            await _vendedorServico.InsertAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }
            var obj = await _vendedorServico.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try {
                await _vendedorServico.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegridadeException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _vendedorServico.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _vendedorServico.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            List<Departamento> departamentos = await _departamentoServico.FindAllAsync();
            VendedorCadastroViewModel viewModel = new VendedorCadastroViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoServico.FindAllAsync();
                var viewModel = new VendedorCadastroViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try {
            await _vendedorServico.UpdateAsync(vendedor);
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
