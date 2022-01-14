using OnlineCarAuction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCarAuction.Models
{
    public class Car : BaseEntity
    {
        public Car() { }
        public Car(string name, string brand, int productionYear, int startPrice)
        {
            Name = name;
            Brand = brand;
            ProductionYear = productionYear;
            StartPrice = startPrice;
            Bids = new List<Bid>();
            IsConfirmed = false;
        }

        public new int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int ProductionYear { get; set; }
        public int StartPrice { get; set; }
        public List<Bid> Bids { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
