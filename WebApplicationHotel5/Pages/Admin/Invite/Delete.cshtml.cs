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
    public class DeleteModel : PageModel
    {
        private readonly WebApplicationHotel5.Data.DataContext _context;

        public DeleteModel(WebApplicationHotel5.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InviteClass = await _context.Invite.FindAsync(id);

            if (InviteClass != null)
            {
                _context.Invite.Remove(InviteClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
