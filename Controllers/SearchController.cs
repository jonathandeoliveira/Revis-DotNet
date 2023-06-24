using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Revis.Models;

namespace Revis.Controllers
{
    public class SearchController : Controller
    {
        Contexto contexto = new Contexto();
        public IActionResult AdvancedSearch()
        {
            var searchModel = new SearchModel();
            return View(searchModel);
        }

        // Action para processar a busca avançada
        [HttpPost]
        public IActionResult AdvancedSearch(SearchModel searchModel)
        {
            List<OficinaModel> oficinasResult = new List<OficinaModel>();
            if (!searchModel.OficinaNome.IsNullOrEmpty())
            {
                oficinasResult.AddRange(contexto.Oficinas.Where(o => o.nome.Contains(searchModel.OficinaNome)).ToList());
            }
            if (!searchModel.OficinaCpnj.IsNullOrEmpty())
            {
                oficinasResult.AddRange(contexto.Oficinas.Where(o => o.cpnj.Contains(searchModel.OficinaCpnj)).ToList());
            }
            if (!searchModel.OficinaCep.IsNullOrEmpty())
            {
                oficinasResult.AddRange(contexto.Oficinas.Where(o => o.cep.Contains(searchModel.OficinaCep)).ToList());
            }
            if (!searchModel.OficinaEndereco.IsNullOrEmpty())
            {
                oficinasResult.AddRange(contexto.Oficinas.Where(o => o.endereco.Contains(searchModel.OficinaEndereco)).ToList());
            }
            if (!searchModel.OficinaCidade.IsNullOrEmpty())
            {
                oficinasResult.AddRange(contexto.Oficinas.Where(o => o.cidade.Contains(searchModel.OficinaCidade)).ToList());
            }
            if (!searchModel.OficinaEstado.IsNullOrEmpty())
            {
                var oficinas = contexto.Oficinas.Where(o => o.estado.Contains(searchModel.OficinaEstado)).ToList();
                oficinasResult.AddRange(oficinas);
            }

            List<MecanicoModel> mecanicosResult = new List<MecanicoModel>();
            if (!searchModel.MecanicoNome.IsNullOrEmpty())
            {
                mecanicosResult.AddRange(contexto.Mecanicos.Where(m => m.nome.Contains(searchModel.MecanicoNome)).ToList());
            }
            if (!searchModel.MecanicoSexo.IsNullOrEmpty())
            {
                mecanicosResult.AddRange(contexto.Mecanicos.Where(m => m.sexo.Contains(searchModel.MecanicoSexo)).ToList());
            }
            if (!searchModel.MecanicoCategoriaDeManutencao.IsNullOrEmpty())
            {
                mecanicosResult.AddRange(contexto.Mecanicos.Where(m => m.categoriaDeManutencao.Contains(searchModel.MecanicoCategoriaDeManutencao)).ToList());
            }
            if (!searchModel.MecanicoResumo.IsNullOrEmpty())
            {
                mecanicosResult.AddRange(contexto.Mecanicos.Where(m => m.resumo.Contains(searchModel.MecanicoResumo)).ToList());
            }


            var searchResults = new SearchModel
            {
                oficinas = oficinasResult,
                mecanicos = mecanicosResult
            };

               return View("AdvancedResults", searchResults);
        }


        public IActionResult AdvancedResults(SearchModel searchModel)
        {
            return View(searchModel);
        }
    }
}
