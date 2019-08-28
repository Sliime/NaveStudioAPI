using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NaveStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NaveStudio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ApiController(ApplicationContext context)
        {
            _context = context;
        }

        
        //public IActionResult GetProdutos()
        //{
        //    var repoProduto = _context.Set<Produto>().ToList();

        //    if (repoProduto.Count == 0)
        //    {
        //        return NotFound();
        //    }


        //    return Ok(repoProduto.ToList());

        //}

        [HttpPost]
        public IActionResult Incluir([FromBody]CadastroHorario model)
        {
            if (ModelState.IsValid)
            {
                IList<CadastroHorario> produtos = _context.Compras
                       .Where(c => model.HoraEntrada <= c.HoraSaida && model.HoraSaida >= c.HoraEntrada).ToList();
                if (produtos.Count == 0)
                {
                    _context.Compras.Add(model);
                    _context.SaveChanges();
                    return Ok();
                }

                return BadRequest("Horario ocupado");
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult GetCadastros(DateTime time)
        {
            if (time < DateTime.Now)
            {
                return BadRequest();

            }

            else {
                var repoCadastro = _context.Set<CadastroHorario>().ToList();


                var horaFiltrada = _context.Compras.Where(p => p.HoraEntrada >= time).Include(p => p.Produto).ToList();

                if (horaFiltrada.Count == 0)
                {
                    return BadRequest("Tem nada");
                }

                return Ok(horaFiltrada.ToList());
            }
        }

    }
}
