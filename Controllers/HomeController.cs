using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revis.Models;
using System.Diagnostics;

namespace Revis.Controllers
{
    public class HomeController : Controller
    {
        Contexto contexto = new Contexto();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult SimpleSearch(string query)  // Realizar a busca simples nas oficinas e funcionários
        {
            var oficinas = contexto.Oficinas.Where(o => (
                     o.nome.Contains(query)) ||
                     o.estado.Contains(query) ||
                     o.cidade.Contains(query) ||
                     o.endereco.Contains(query) ||
                     o.mecanicos.Any(m => m.nome.Contains(query)) ||
                     o.mecanicos.Any(m => m.sexo == query) ||
                     o.mecanicos.Any(m => m.categoriaDeManutencao.Contains(query)) ||
                     o.mecanicos.Any(m => m.resumo.Contains(query))
                     ).Distinct().ToList();
            var mecanicos = contexto.Mecanicos.Where(
                m => m.nome.Contains(query) ||
                     m.resumo.Contains(query)

                ).Distinct().ToList();

            ViewBag.oficinas = oficinas;
            ViewBag.mecanicos = mecanicos;

            return View();
        }

    }
}