﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Auction.Data.ApplicationDbContext _context;

        public DetailsModel(Auction.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
