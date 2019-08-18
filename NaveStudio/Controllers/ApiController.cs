using Microsoft.AspNetCore.Mvc;
using NaveStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaveStudio.Controllers
{
    public class ApiController : Controller
    {
        private readonly ApplicationContext _context;

        public ApiController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProdutos()
        {
            var repoProduto = _context.Set<Produto>().ToList();

            if (repoProduto.Count == 0)
            {
                return NotFound();
            }


            return Json(repoProduto.ToList());

        }

        [HttpPost]
        public IActionResult Incluir(CadastroHorario model)
        {
            if (ModelState.IsValid)
            {
                _context.Set<CadastroHorario>().Add(model);
            }

            return NotFound();
        }
    }
}
