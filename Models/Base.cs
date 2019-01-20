using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Yacht.Models
{
    public class Base
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
    }
}
