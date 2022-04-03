using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationHotel5.Models
{
    public class ChambreClass
    {
        [Key]
        public int ChambreID { get; set; }
        public string NomChambre { get; set; }
        public double Prix { get; set; }
    }
}
