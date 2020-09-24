using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    public class Prix
    {
        public Prix()
        {
            this.Chambres = new HashSet<Chambre>();
        }

        [Key]
        public int idPrix { get; set; }

        [Required]
        public Decimal prix { get; set; }

        [Required]
        public int NbNuit { get; set; }

        public virtual ICollection<Chambre> Chambres { get; set; }
    }
}
