using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    public class Reservation
    {
        [Key]
        public int IdentifiantRes { get; set; }

        [Required]
        public DateTime? DateReservation { get; set; }

        [Required]
        public DateTime? DateDebutSejour { get; set; }

        [Required]
        public int NbNuits { get; set; }

        [ForeignKey("Client")]
        public int IdentifiantCli { get; set; }
        public Client Client { get; set; }

    }
}
