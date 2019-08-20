using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                IList<CadastroHorario> produtos = _context.Compras
                       .Where(c => model.horaEntrada <= c.horaSaida && model.horaSaida >= c.horaEntrada).ToList();
                if (produtos.Count == 0)
                {
                    _context.Compras.Add(model);
                    _context.SaveChanges();
                    return Ok();
                }

                return NotFound();
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult GetCadastros(DateTime time)
        {
            if (time < DateTime.Now)
            {
                return NotFound();

            }

            else {
                var repoCadastro = _context.Set<CadastroHorario>().ToList();


                var horaFiltrada = _context.Compras.Where(p => p.horaEntrada >= time).Include(p => p.Produto).ToList();

                if (horaFiltrada.Count == 0)
                {
                    return NotFound();
                }

                return Json(horaFiltrada.ToList());
            }
        }

    }
}
