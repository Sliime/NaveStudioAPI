using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NaveStudio.Models;
using NaveStudio;

namespace NaveStudio.Controllers
{


   




    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;

            
            
        }
        [HttpGet]
        public IActionResult GetProdutos()
        {
            var but =_context.Set<Produto>().ToList();
            
            

            return Json(but.ToList());

        }

        public IActionResult Index()
        {

           // Produto p = new Produto("2", "Ensaio", 50);

           // _context.Set<Produto>().Add(p);
           // _context.SaveChanges();

            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
