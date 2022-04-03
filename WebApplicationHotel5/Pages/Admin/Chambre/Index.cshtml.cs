using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationHotel5.Data;
using WebApplicationHotel5.Models;

namespace WebApplicationHotel5.Pages.Admin.Chambre
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly WebApplicationHotel5.Data.DataContext _context;

        public IndexModel(WebApplicationHotel5.Data.DataContext context)
        {
            _context = context;
        }

        public IList<ChambreClass> ChambreClass { get;set; }

        public async Task OnGetAsync()
        {
            ChambreClass = await _context.Chambre.ToListAsync();
        }
    }
}
