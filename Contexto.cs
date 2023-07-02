using Revis.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Revis.Areas.Identity.Data;

namespace Revis
{
    public class Contexto : IdentityDbContext<ApplicationUser>
    {
        public DbSet<OficinaModel> Oficinas { get; set; }
        public DbSet<MecanicoModel> Mecanicos { get; set; }
        public static IEnumerable<object> MecanicoModel { get; internal set; }

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
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");

            base.OnModelCreating(modelBuilder);
        }


    }
}
