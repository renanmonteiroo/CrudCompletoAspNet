using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuCrudCompleto.Models;

namespace MeuCrudCompleto.Controllers
{
    public class DepartamentosController : Controller
    {

              public IActionResult Index()
        {
            List<Departamento> list = new List<Departamento>();
            list.Add(new Departamento { id = 1, nome = "Eletronicos" });
            list.Add(new Departamento { id = 2, nome = "Eletro - Domesticos" });

            return View(list);
        }
    }
}
