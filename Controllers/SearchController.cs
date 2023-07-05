using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Revis.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            string query = @"
                SELECT DISTINCT m.id, m.nome, m.sexo, m.categoriaDeManutencao, m.resumo, m.oficinaId
                FROM Mecanicos m
                JOIN Oficinas o ON m.oficinaId = o.id
                WHERE (m.nome LIKE '%' + @mecanicoNome + '%' OR @mecanicoNome = '' )
                    AND (m.sexo LIKE '%' + @mecanicoSexo + '%' OR @mecanicoSexo = '')       
                    AND (m.categoriaDeManutencao LIKE '%' + @mecanicoCategoriaDeManutencao + '%' OR @mecanicoCategoriaDeManutencao = '')
                    AND (m.resumo LIKE '%' + @mecanicoResumo + '%' OR @mecanicoResumo = '')
                    AND (o.nome LIKE '%' + @oficinaNome + '%' OR @oficinaNome = '')
                    AND (o.cidade LIKE '%' + @oficinaCidade + '%' OR @oficinaCidade = '')
                    AND (o.estado LIKE '%' + @oficinaEstado + '%' OR @oficinaEstado = '')";

            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Revis;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);


                //Os ifs são para fazer a proteção contra sql injection nos campos preenchidos 
                //os elses são para considerar como espaços vazios na query sql.
                if (!searchModel.MecanicoNome.IsNullOrEmpty()) 
                {
                    sqlCommand.Parameters.AddWithValue("@mecanicoNome", searchModel.MecanicoNome);
                }
                else { sqlCommand.Parameters.AddWithValue("@mecanicoNome", ""); }

                if (!searchModel.MecanicoSexo.IsNullOrEmpty())
                {
                    sqlCommand.Parameters.AddWithValue("@mecanicoSexo", searchModel.MecanicoSexo);
                }
                else { sqlCommand.Parameters.AddWithValue("@mecanicoSexo", ""); }

                if (!searchModel.MecanicoCategoriaDeManutencao.IsNullOrEmpty())
                {
                    sqlCommand.Parameters.AddWithValue("@mecanicoCategoriaDeManutencao", searchModel.MecanicoCategoriaDeManutencao);
                }
                else { sqlCommand.Parameters.AddWithValue("@mecanicoCategoriaDeManutencao", ""); }

                if (!searchModel.MecanicoResumo.IsNullOrEmpty())
                {
                    sqlCommand.Parameters.AddWithValue("@mecanicoResumo", searchModel.MecanicoResumo);
                }
                else { sqlCommand.Parameters.AddWithValue("@mecanicoResumo", ""); }

                if (!searchModel.OficinaCidade.IsNullOrEmpty())
                {
                    sqlCommand.Parameters.AddWithValue("@oficinaCidade", searchModel.OficinaCidade);
                }
                else { sqlCommand.Parameters.AddWithValue("@oficinaCidade", ""); }

                if (!searchModel.OficinaEstado.IsNullOrEmpty())
                {
                    sqlCommand.Parameters.AddWithValue("@oficinaEstado", searchModel.OficinaEstado);
                }
                else { sqlCommand.Parameters.AddWithValue("@oficinaEstado", ""); }


                if (!searchModel.OficinaNome.IsNullOrEmpty())
                {
                    sqlCommand.Parameters.AddWithValue("@oficinaNome", searchModel.OficinaNome);
                }
                else { sqlCommand.Parameters.AddWithValue("@oficinaNome", ""); }

                connection.Open();

                List<MecanicoModel> mecanicos = new List<MecanicoModel>();

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MecanicoModel mecanico = new MecanicoModel();
                        mecanico.id = reader.GetInt32(0);
                        mecanico.nome = reader.GetString(1);
                        mecanico.sexo = reader.GetString(2);
                        mecanico.categoriaDeManutencao = reader.GetString(3);
                        mecanico.resumo = reader.GetString(4);
                        mecanico.oficinaId = reader.GetInt32(5);

                        OficinaModel oficina = contexto.Oficinas.FirstOrDefault(o => o.id == mecanico.oficinaId);
                        mecanico.oficina = oficina;
                        mecanicos.Add(mecanico);
                    }
                }

                return View("AdvancedResults", mecanicos);
            }
        }
          

        public IActionResult AdvancedResults(SearchModel searchModel)
        {
            return View(searchModel);
        }
    }
}
