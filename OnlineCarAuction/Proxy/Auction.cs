using System.Collections.Generic;
using OnlineCarAuction.Models;
using OnlineCarAuction.Repository;

namespace OnlineCarAuction.Observer
{
    public class AuctionRealObject
    {
        private Car _auction;

        public Car createAuction(string Name,  string Brand, int ProductionYear, int StartPrice)
        {
            _auction = new Car(Name, Brand, ProductionYear, StartPrice);
            return _auction;
        }

        public void deleteAuction()
        {
            _auction = null;
        }

        public void confirm()
        {
            _auction.IsConfirmed = true;
        }

        public void bid(int Price)
        {
            _auction.Bids.Add(new Bid(Price, _auction.Id));
        }
    }

    public class AdminProxy
    {
        private AuctionRealObject _subject;
        public AdminProxy(AuctionRealObject RealSubject)
        {
            _subject = RealSubject;
        }

        public void confirm()
        {
            _subject.confirm();
        }

        public void deleteAuction()
        {
            _subject.deleteAuction();
        }
    }

    public class BuyerProxy
    {
        private AuctionRealObject _subject;
        public BuyerProxy(AuctionRealObject RealSubject)
        {
            _subject = RealSubject;
        }

        public void bid(int Price)
        {
            _subject.bid(Price);
        }

    }



    class Program1
    {

        void Main1()
        {
            AuctionRealObject auctionObj = new AuctionRealObject();
            auctionObj.createAuction("W223", "Mercedes", 2021, 200000);

            AdminProxy adminProxy = new AdminProxy(auctionObj);
            adminProxy.confirm();

            BuyerProxy buyerProxy = new BuyerProxy(auctionObj);
            buyerProxy.bid(210000);
        }
    }


}
