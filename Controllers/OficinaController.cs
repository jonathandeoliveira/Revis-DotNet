using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revis.Models;
using System.Linq;

namespace Revis.Controllers
{
    public class OficinaController : Controller
    {
        Contexto contexto = new Contexto();
        public IActionResult Index()
        {
           
            try
            {
                List<OficinaModel> oficinas = (from OficinaModel p in contexto.Oficinas select p).Include(ofc => ofc.mecanicos).ToList<OficinaModel>();
                /*foreach (OficinaModel item in oficinas)
                {
                    Console.WriteLine(item.nome);
                    foreach (Email itemMecanico in item.mecanicos)
                    {

                        Console.WriteLine("\t" + itemMecanico.email);

                    }
                    Console.WriteLine();
                }*/
                return View(oficinas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();

            }
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Show(int id)
        {
            OficinaModel oficina = contexto.Oficinas.Find(id);
            if (oficina == null)
            {
                return View("Error");
            }
            List<MecanicoModel> mecanicos = contexto.Mecanicos.Where(m => m.oficina.id == id).ToList();

            ViewBag.Oficina = oficina;
            ViewBag.Mecanicos = mecanicos;
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
