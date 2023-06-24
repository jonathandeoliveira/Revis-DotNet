﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revis.Models;

namespace Revis.Controllers
{
    public class MecanicoController : Controller
    {
        Contexto contexto = new Contexto();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int oficinaId)
        {
            OficinaModel oficina = contexto.Oficinas.Find(oficinaId);
            if (oficina != null)
            {
                MecanicoModel mecanico = new MecanicoModel();
                mecanico.oficina = oficina;
                ViewData["OficinaId"] = oficinaId;
                return View("Create", mecanico);
            }
            else { return View(); } // retornar uma mensagem de erro futuramente
        }
    }
}
