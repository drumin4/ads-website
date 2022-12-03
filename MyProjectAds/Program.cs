using MyProjectAds;

Console.WriteLine("Type a command to explore our app! (list / view bydate / view / fav/ listfav/ deletefav/ listby$/ listsearch");

Page home = new Page();
home.LoadData(@"D:\MyProjects\FirstProject\MyProjectAds\anunturi.csv");


List<Ad> ListOfFavorites = new List<Ad>();
string command = "";
while(command != "exit") 
{
    command = Console.ReadLine();
    
    switch (command)
    {
        case "list":
            {
                home.ShowAll();
                break;
            }
        case "view bydate":
            {
                home.Ads = home.Ads.OrderByDescending(a => a.Published).ToList();
                home.ShowAll();
                break;
            }
        case "view":
            {
                Console.WriteLine("Enter an ad ID: ");
                int adID = Convert.ToInt32(Console.ReadLine());
                Ad AdSelected = home.Ads.Find(x => x.Id == adID);
                if (AdSelected != null)
                    AdSelected.ShowAllDetails();
                else
                    throw new Exception("The ad you were attempting to find is missing.");
                break;
            }
        case "fav":
            {
                Console.WriteLine("Enter an ad ID: ");
                int adID = Convert.ToInt32(Console.ReadLine());
                Ad AdSelected = home.Ads.Find(x => x.Id == adID);
                if (AdSelected != null)
                {
                    ListOfFavorites.Add(AdSelected);
                }
    
                break;
            }
        case "listfav":
            {
                foreach (Ad ad in ListOfFavorites)
                    ad.ShowSummary();
                
    
                break;
            }
        case "deletefav":
            {
                Console.WriteLine("Enter an ad ID from your favorites: ");
                int adID = Convert.ToInt32(Console.ReadLine());

                Ad found = ListOfFavorites.Find(a => a.Id == adID);
                if (found != null)
                {
                    ListOfFavorites.Remove(found);
                }
                break;
            }
        case "listby$":
            {
                Console.WriteLine("Specifica pretul minim:");
                string min = Console.ReadLine();
                Console.WriteLine("Specifica pretul maxim");
                string max = Console.ReadLine();
                double minPrice = Convert.ToDouble(min);
                double maxPrice = Convert.ToDouble(max);

                List<Ad> filteredAds = home.Ads.Where(a => 
                    a.Price >= minPrice && a.Price <= maxPrice).ToList();
                foreach(var ad in filteredAds)
                {
                    ad.ShowSummary();
                }
                break;
            }
        case "listsearch":
            {
                Console.WriteLine("Cuvintele cheie:");
                string query = Console.ReadLine();
                List<Ad> filtered = home.Ads.Where(a =>
                    a.Title.Contains(query) || a.Details.Contains(query)).ToList();
                foreach(var ad in filtered)
                {
                    ad.ShowSummary();
                }
                break;
            }
    }
}
