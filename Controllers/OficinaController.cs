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

        public IActionResult CreateMecanico(int oficinaId)
        {
            OficinaModel oficina = contexto.Oficinas.Find(oficinaId);

            if (oficina == null)
            {
                return RedirectToRoute("/Oficina");
            }

            MecanicoModel mecanico = new MecanicoModel();
            ViewData["OficinaId"] = oficinaId; // Passa o ID da oficina para a view usando ViewData
            return View("CreateMecanico", mecanico);
        }

        [HttpPost]
        public IActionResult CreateMecanico(MecanicoModel mecanico, int oficinaId)
        {
            OficinaModel oficina = contexto.Oficinas.Find(oficinaId);

            if (oficina != null)
            {
                mecanico.oficina = oficina; // Atribui o ID da oficina à propriedade oficinaId
                contexto.Mecanicos.Add(mecanico);
                contexto.SaveChanges();
            }
            return RedirectToAction("Show", new { id = oficinaId });
        }

    }
}
