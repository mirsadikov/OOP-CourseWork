using OnlineCarAuction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCarAuction.Models
{
    public class Bid : BaseEntity
    {
        public Bid(int rate, int carId)
        {
            Rate = rate;
            CarId = carId;
        }

        public Bid() { }

        public int Rate { get; set; }
        public int CarId { get; set; }


    }
}
