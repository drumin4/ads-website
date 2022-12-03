using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectAds
{
    public class Ad
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public DateTime Published { get; set; }

        public string Location { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public string Contact { get; set; }

        public void ShowSummary()
        {
            string display = $"{this.Title} - {this.Published} - {this.Details}. Location: {this.Location}. " +
                $"Price: {this.Price}.";
            Console.WriteLine("\n----------------------\n" + display + "\n----------------------\n");
        }
        
        public void ShowAllDetails()
        {
            string display = $"{this.Title}\n - {this.Published}\n - {this.Details}\n - {this.Contact}.\n Location: {this.Location}.\n " +
                $"Price: {this.Price}.\n See image: {this.ImageUrl}";
            Console.WriteLine("\n----------------------\n" + display + "\n----------------------\n");
        }

        public static Ad CreateObjectFromCsvLine(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Ad ad = new Ad();
            ad.Id = Convert.ToInt32(values[0]);
            ad.Title = values[1];
            ad.Details = values[2];
            ad.Published = DateTime.ParseExact(values[3], "dd-MM-yy", null);
            ad.Location = values[4];
            ad.ImageUrl = values[5];
            ad.Contact = values[6];
            ad.Price = Convert.ToDouble(values[7]);

            return ad;
        }
    }
}
