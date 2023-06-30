using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revis.Models;
using System.Linq;
using System.Text.RegularExpressions;

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
            ViewBag.Mecanicos = mecanicos;
            ViewBag.Oficina = oficina;
            if (TempData.ContainsKey("MensagemCadastro"))
            {
                ViewBag.Message = TempData["MensagemCadastro"];
            }

            return View(oficina);
        }

        [HttpPost]
        public IActionResult Create(OficinaModel oficina)
        {
            oficina.mecanicos = new List<MecanicoModel>(); 
            if (!ModelState.IsValid)
            {
                TempData["MensagemCadastro"] = "Houve algum erro durante o cadastro!";
                return BadRequest(ModelState);
            }
            oficina.mecanicos = new List<MecanicoModel>();
            Contexto contexto = new Contexto();
            contexto.Oficinas.Add(oficina);
            contexto.SaveChanges();
            TempData["MensagemCadastro"] = "Oficina cadastrada com sucesso!";
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
            ViewData["OficinaId"] = oficinaId;
            return View("CreateMecanico", mecanico);
        }

        [HttpPost]
        public IActionResult CreateMecanico(MecanicoModel mecanico, int oficinaId)
        {
            OficinaModel oficina = contexto.Oficinas.Find(oficinaId);

            if (oficina != null)
            {
                mecanico.oficina = oficina;
                contexto.Mecanicos.Add(mecanico);
                contexto.SaveChanges();
                TempData["MensagemCadastro"] = "Mecânico(a) cadastrado com sucesso!";
            }
            else { TempData["MensagemCadastro"] = "Houve algum erro durante o cadastro!"; }
            
            return RedirectToAction("Show", new { id = oficinaId });
        }

    }
}
