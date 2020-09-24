using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    public class Client
    {
        [Key]
        public int IdentifiantCli { get; set; }

        [Required]
        [StringLength(25)]
        public string Nom { get; set; }

        [Required]
        [StringLength(25)]
        public string Prenom { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Telephone { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
