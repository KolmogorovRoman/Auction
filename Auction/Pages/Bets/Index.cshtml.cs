using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Auction.Data;
using Auction.Models;

namespace Auction.Pages.Bets
{
    public class IndexModel : PageModel
    {
        private readonly Auction.Data.ApplicationDbContext _context;

        public IndexModel(Auction.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Bet> Bet { get;set; }

        public async Task OnGetAsync()
        {
            Bet = await _context.Bets
                .Include(b => b.Lot).ToListAsync();
        }
    }
}
