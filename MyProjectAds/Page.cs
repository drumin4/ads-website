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


        //public Page()
        //{
        //    Varianta 1:

        //    Ads = new List<Ad>();
        //    Favorites = new List<Ad>();
        //    {
        //        new Ad
        //        {
        //            Id = 1,
        //            Title = "Vand casa",
        //            Details = "Vand casa Floresti, complet utilata",
        //            Location = "Cluj",
        //            Price = 520000,
        //            Published = DateTime.Now.AddDays(-2),
        //            Contact = "07xxxxx123",
        //            ImageUrl = "https://www.eproiectedecase.ro/wp-content/uploads/2017/02/Proiect-casa-cu-Mansarda-18011-perspectiva2-1500x954.jpg"
        //        },
        //            new Ad
        //            {
        //                Id = 2,
        //                Title = "Inchiriez apartament",
        //                Details = "Inchiriez apartament - Brasov, centrul istoric",
        //                Location = "Brasov",
        //                Price = 450,
        //                Published = DateTime.Now.AddDays(-1),
        //                Contact = "0787234891",
        //                ImageUrl = "https://nuscocitta.ro/wp-content/uploads/2017/12/Apartament-2-camere.jpg"
        //            }
        //}


            public void ShowAll()
        {
                foreach(Ad item in Ads)
                {
                    item.ShowSummary();
                }
        }

            //Varianta 2:

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
