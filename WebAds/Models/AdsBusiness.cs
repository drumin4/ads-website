using MyProjectAds;

namespace WebAds.Models
{
    public class AdsBusiness
    {
        public Page Page { get; set; }
        public AdsBusiness()
        {
            Page = new Page();
            Page.LoadData(@"D:\MyProjects\FirstProject\MyProjectAds\anunturi.csv");
        }

        public List<Ad> ListByDateDesc()
        {
            return this.Page.Ads.OrderByDescending(a => a.Published).ToList();
        }

        public List<Ad> ListByPriceDesc()
        {
            return this.Page.Ads.OrderByDescending(a => a.Price).ToList();
        }

        public List<Ad> ListByPriceAsc()
        {
            return this.Page.Ads.OrderBy(a => a.Price).ToList();
        }

        public Ad GetById(int id)
        {
            return this.Page.Ads.Find(a => a.Id == id);
        }

        public List<Ad> FilterByPrice(double from, double to)
        {
            return this.Page.Ads.Where(a =>
                a.Price >= from && a.Price <= to).ToList();
        }

        public List<Ad> Search(string criteria)
        {
            return this.Page.Ads.Where(a =>
                a.Title.Contains(criteria) || a.Details.Contains(criteria)).ToList();
        }
    }
}
