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

namespace WebApplicationHotel5.Pages.Admin.Invite
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly WebApplicationHotel5.Data.DataContext _context;

        public DetailsModel(WebApplicationHotel5.Data.DataContext context)
        {
            _context = context;
        }

        public InviteClass InviteClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InviteClass = await _context.Invite.FirstOrDefaultAsync(m => m.InviteID == id);

            if (InviteClass == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
