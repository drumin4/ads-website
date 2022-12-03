using WebAds.Models;

namespace WebAdsTests
{
    [TestClass]
    public class BusinessTests
    {
        [TestMethod]
        public void TestListByDateDesc()
        {
            AdsBusiness business = new AdsBusiness();
            var adsByDateDesc = business.ListByDateDesc();

            Assert.IsTrue(adsByDateDesc[0].Published > adsByDateDesc[1].Published);
        }

        [TestMethod]
        public void TestListByPriceDesc()
        {
            AdsBusiness business = new AdsBusiness();
            var adsByPriceDesc = business.ListByPriceDesc();

            Assert.IsTrue(adsByPriceDesc[0].Price > adsByPriceDesc[1].Price &&
                adsByPriceDesc[0].Price > adsByPriceDesc[adsByPriceDesc.Count - 1].Price);
        }
        
        [TestMethod]
        public void TestListByPriceAsc()
        {
            AdsBusiness business = new AdsBusiness();
            var adsByPriceAsc = business.ListByPriceAsc();

            Assert.IsTrue(adsByPriceAsc[0].Price < adsByPriceAsc[1].Price &&
                adsByPriceAsc[0].Price < adsByPriceAsc[adsByPriceAsc.Count - 1].Price);
        }

        [TestMethod]
        public void TestFilterByPrice()
        {
            double from = 3;
            double to = 500;
            AdsBusiness business = new AdsBusiness();

            var adsByPrice = business.FilterByPrice(from, to);
            Assert.IsTrue(adsByPrice.TrueForAll(a => a.Price <= to && a.Price >= from));
        }

        [TestMethod]
        public void Search()
        {
            string q = "Vand";
            AdsBusiness b = new AdsBusiness();

            var found = b.Search(q);

            Assert.IsTrue(found.All(a => a.Title.Contains(q) || a.Details.Contains(q)));
        }
    }
}