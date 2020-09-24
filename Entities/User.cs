using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    public class User
    {
        [Key]
        [StringLength(80)]
        public string Identifiant { get; set; }

        [Required]
        [StringLength(80)]
        public string Role { get; set; }
        
        [StringLength(80)]
        public string Email { get; set; }
    }
}
