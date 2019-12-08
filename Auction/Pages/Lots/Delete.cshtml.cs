using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Auction.Data;
using Auction.Models;

namespace Auction.Pages.Lots
{
    public class DeleteModel : PageModel
    {
        private readonly Auction.Data.ApplicationDbContext _context;

        public DeleteModel(Auction.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lot Lot { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lot = await _context.Lots.FirstOrDefaultAsync(m => m.ID == id);

            if (Lot == null)
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

            Lot = await _context.Lots.FindAsync(id);

            if (Lot != null)
            {
                _context.Lots.Remove(Lot);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
