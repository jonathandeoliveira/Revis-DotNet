using Revis.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revis
{
    public class Contexto : DbContext
    {
        public DbSet<OficinaModel> Oficinas { get; set; }
        public DbSet<MecanicoModel> Mecanicos { get; set; }
        public Contexto() { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConnectionStringSettings settings = System.Configuration.ConfigurationManager.ConnectionStrings["EntityAtos"];
            string retorno = "";
            if (settings != null)
            {
                retorno = settings.ConnectionString;
            }
            optionsBuilder.UseSqlServer(retorno);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MecanicoModel>().HasOne(e => e.oficina).WithMany(e => e.mecanicos).OnDelete(DeleteBehavior.Cascade);

        }


    }
}
