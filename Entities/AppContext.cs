using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AppContext : DbContext
    {
        public AppContext() : base()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Chambre> Chambres { get; set; }
        public DbSet<Prix> lstPrix { get; set; }

        public DbSet<ChambreReservee> ChambreReservees { get; set; }

        public DbSet<DemandeOption> DemandeOptions { get; set; }

        public DbSet<Option> Options { get; set; }

        public DbSet<Repas> Repas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
