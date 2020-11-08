using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    public class DemandeOption
    {
        [Key]
        [Column(Order = 1)]
        public int IdChambreReservee { get; set; }

        [Key]
        [Column(Order = 2)]
        public int IdOption { get; set; }

        [ForeignKey("IdChambreReservee")]
        public ChambreReservee ChambreReservee { get; set; }

        [ForeignKey("IdOption")]
        public Option Option { get; set; }

        [Required]
        public int NbJour { get; set; }
    }
}
