using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Auction.Data;
using Auction.Models;
using Microsoft.AspNetCore.Identity;

namespace Auction.Pages.Bets
{
    public class CreateModel : PageModel
    {
        private readonly Auction.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(Auction.Data.ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["LotID"] = new SelectList(_context.Lots, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Bet Bet { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Lot lot = _context.Lots.Where(lot => lot.ID == Bet.ID).FirstOrDefault();
            if (lot != null)
                lot.CurrentBet = Bet;
            Bet.User = await _userManager.GetUserAsync(User);
            _context.Bets.Add(Bet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
