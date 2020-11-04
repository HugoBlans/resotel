using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    public class ChambreReservee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NbPersonne { get; set; }

        [ForeignKey("Reservation")]
        public int IdentifiantRes { get; set; }
        public Reservation Reservation { get; set; }

        [ForeignKey("Chambre")]
        public int Numero { get; set; }

        public Chambre Chambre { get; set; }
    }
}
