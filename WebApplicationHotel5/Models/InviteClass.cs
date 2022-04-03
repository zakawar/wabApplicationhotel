using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationHotel5.Models
{
    public class InviteClass
    {
        [Key]
        public int InviteID { get; set; }
        public string NomInvite { get; set; }
        public string PrenomInvite { get; set; }
        public string Telephone { get; set; }
        public int ChambreID  { get; set; }

    }
}
