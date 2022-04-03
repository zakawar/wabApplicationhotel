using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationHotel5.Data;
using WebApplicationHotel5.Models;

namespace WebApplicationHotel5.Pages.Admin.Chambre
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly WebApplicationHotel5.Data.DataContext _context;

        public EditModel(WebApplicationHotel5.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ChambreClass ChambreClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChambreClass = await _context.Chambre.FirstOrDefaultAsync(m => m.ChambreID == id);

            if (ChambreClass == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ChambreClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChambreClassExists(ChambreClass.ChambreID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChambreClassExists(int id)
        {
            return _context.Chambre.Any(e => e.ChambreID == id);
        }
    }
}
