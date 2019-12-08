using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Models
{
    public class Lot
    {
        public int ID { get; set; }
        public int StartCost { get; set; }
        public int ReserveCost { get; set; }
        public int Steep { get; set; }
        public DateTime CreationTime { get; set; }
        public Bet CurrentBet { get; set; }
        
    }
}
