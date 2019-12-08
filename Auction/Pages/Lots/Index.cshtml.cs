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
    public class IndexModel : PageModel
    {
        private readonly Auction.Data.ApplicationDbContext _context;

        public IndexModel(Auction.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Lot> Lots { get;set; }

        public async Task OnGetAsync()
        {
            Lots = await _context.Lots.ToListAsync();
        }
    }
}
