using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    public class Chambre
    {
        public Chambre()
        {
            this.LstPrix = new HashSet<Prix>();
        }
        [Key]
        public int Numero { get; set; }

        [Required]
        public int NbLit { get; set; }

        [Required]
        public bool LitEnfant { get; set; }

        [Required]
        public bool LitDouble { get; set; }

        [Required]
        public DateTime DateDernierMenage { get; set; }

        public virtual ICollection<Prix> LstPrix { get; set; }
    }
}
