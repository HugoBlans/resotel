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
    class UserContext : DbContext
    {
        public UserContext() : base()
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
