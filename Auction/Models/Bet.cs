using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Auction.Models
{
    public class Bet
    {
        public int ID { get; set; }
        public Lot Lot { get; set; }
        public int LotID { get; set; }
        public IdentityUser User { get; set; }
        public int Size { get; set; }
    }
}
