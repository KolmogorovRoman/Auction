using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Auction.Data;
using Auction.Models;

namespace Auction.Pages.Bets
{
    public class EditModel : PageModel
    {
        private readonly Auction.Data.ApplicationDbContext _context;

        public EditModel(Auction.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bet Bet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bet = await _context.Bets
                .Include(b => b.Lot).FirstOrDefaultAsync(m => m.ID == id);

            if (Bet == null)
            {
                return NotFound();
            }
           ViewData["LotID"] = new SelectList(_context.Lots, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BetExists(Bet.ID))
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

        private bool BetExists(int id)
        {
            return _context.Bets.Any(e => e.ID == id);
        }
    }
}
