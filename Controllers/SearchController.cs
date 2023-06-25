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
        {/*
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
            oficinasResult.ForEach(oficina => { mecanicosResult.AddRange(oficina.mecanicos)}); ;

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

            if (mecanicosResult.Any())
            {
                mecanicosResult = mecanicosResult
                .GroupBy(m => new { m.nome, m.cpf, m.sexo }) // Agrupar por propriedades relevantes
                .Select(g => g.First()) // Selecionar o primeiro registro de cada grupo
                .ToList();
                oficinasResult = oficinasResult.Where(o => mecanicosResult.Any(m => m.oficinaId == o.id)).ToList();

            }*/
            List<OficinaModel> oficinasResult = new List<OficinaModel>();
            oficinasResult = contexto.Oficinas
                .Where(o => (
                    (searchModel.OficinaNome.IsNullOrEmpty() || o.nome.Contains(searchModel.OficinaNome)) &&
                    (searchModel.OficinaEstado.IsNullOrEmpty() || o.estado.Contains(searchModel.OficinaEstado)) &&
                    (searchModel.OficinaCidade.IsNullOrEmpty() || o.cidade.Contains(searchModel.OficinaCidade)) &&
                    (searchModel.OficinaEndereco.IsNullOrEmpty() || o.endereco.Contains(searchModel.OficinaEndereco)) &&
                    (searchModel.MecanicoNome.IsNullOrEmpty() || o.mecanicos.Any(m => m.nome.Contains(searchModel.MecanicoNome))) &&
                    (searchModel.MecanicoSexo.IsNullOrEmpty() || o.mecanicos.Any(m => m.sexo == searchModel.MecanicoSexo)) &&
                    (searchModel.MecanicoCategoriaDeManutencao.IsNullOrEmpty() || o.mecanicos.Any(m => m.categoriaDeManutencao.Contains(searchModel.MecanicoCategoriaDeManutencao))) &&
                    (searchModel.MecanicoResumo.IsNullOrEmpty() || o.mecanicos.Any(m => m.resumo.Contains(searchModel.MecanicoResumo)))
                ))
                .ToList();
            oficinasResult = oficinasResult.Distinct().ToList();
            List<MecanicoModel> mecanicosResult = new List<MecanicoModel>();

            foreach (var oficina in oficinasResult)
            {
                 mecanicosResult = contexto.Mecanicos
                    .Where(m => m.oficinaId == oficina.id &&
                        (searchModel.MecanicoNome.IsNullOrEmpty() || m.nome.Contains(searchModel.MecanicoNome)) &&
                        (searchModel.MecanicoSexo.IsNullOrEmpty() || m.sexo == searchModel.MecanicoSexo) &&
                        (searchModel.MecanicoCategoriaDeManutencao.IsNullOrEmpty() || m.categoriaDeManutencao == (searchModel.MecanicoCategoriaDeManutencao)) &&
                        (searchModel.MecanicoResumo.IsNullOrEmpty() || m.resumo.Contains(searchModel.MecanicoResumo)))
                    .ToList();

                oficina.mecanicos = mecanicosResult;
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
