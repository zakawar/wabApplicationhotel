using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationHotel5.Models;

namespace WebApplicationHotel5.Pages
{
    public class ListeChambresModel : PageModel
    {
        private readonly WebApplicationHotel5.Data.DataContext _context;
        public ListeChambresModel(WebApplicationHotel5.Data.DataContext dataContext)
        {
            _context = dataContext;
        }

        public IEnumerable<ChambreClass> Getchambres { get; set; }
        public void OnGet()
        {
            Getchambres = _context.Chambre.ToList();
        }

        public void OnGetSelect()
        {
            //var choose = Getchambres.Where(s => s.ChambreID == ID);

        }
    }
}
