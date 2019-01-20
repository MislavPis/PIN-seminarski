using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Yacht.Models
{
    public class Dostupnost
    {
        public int Id { get; set; }

        public int ModelId { get; set; }
        public Tip Model { get; set; }

        [Required]
        public string Naziv { get; set; }

        public int BaseId { get; set; }
        public Base Baza { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Availability { get; set; }
    }
}
