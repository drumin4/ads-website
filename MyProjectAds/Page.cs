using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectAds
{
    public class Page
    {
        public List<Ad> Ads { get; set; }

        public OrderBy OrderBy { get; set; }

        public void ShowAll()
        {
            foreach(Ad item in Ads)
            {
                item.ShowSummary();
            }
        }

        public void LoadData(string filePath)
        {
            List<Ad> ads = File.ReadAllLines(filePath)
                .Skip(1)
                .Select(line => Ad.CreateObjectFromCsvLine(line))
                .ToList();

            this.Ads = ads;
        }
    }

    public enum OrderBy
    {
        PublishedDate,
        PublishedDateDesc,
        Title,
        TitleDesc,
        Location,
        LocationDesc,
        Price,
        PriceDesc
    }
}
