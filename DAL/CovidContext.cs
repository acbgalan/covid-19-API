using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Covid19.DAL.Models;

namespace Covid19.DAL
{
    public class CovidContext : DbContext
    {
        public CovidContext() : base("COVID-19") { }

        public DbSet<Cuestionario> Cuestionarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
