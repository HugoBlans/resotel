using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    class Repas
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool EstPetitDejeuner { get; set; }

        [Required]
        public DateTime DateRepas { get; set; }

        [ForeignKey("ChambreReservee")]
        public int IdChambreReservee { get; set; }
        public ChambreReservee ChambreReservee { get; set; }
    }
}
