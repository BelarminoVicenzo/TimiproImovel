using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimiProImovel.Models;

namespace Timipro.DataAccess
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() : base("name=TimiproImovel")
        {
            //prevent creating a new db 77
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Imovel> Imovel { get; set; }
        public DbSet<TipoNegocio> TipoNegocio { get; set; }
        public DbSet<ClienteImovel> ClienteImovel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //for plural names, this will prevent
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    


    }


}
