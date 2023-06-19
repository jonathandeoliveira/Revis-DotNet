using Microsoft.AspNetCore.Mvc;
using Revis.Models;
using Revis.Repositorio;

namespace Revis.Controllers
{
    public class OficinaController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OficinaModel oficina)
        {
            Contexto contexto = new Contexto();
            contexto.Oficinas.Add(oficina);
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
