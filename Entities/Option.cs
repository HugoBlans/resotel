using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    public class Option
    {
        [Key]
        public int NumOption { get; set; }

        [Required]
        [StringLength(50)]
        public string Designation { get; set; }

        [Required]
        public decimal Prix { get; set; }
    }
}
