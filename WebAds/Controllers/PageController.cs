using Microsoft.AspNetCore.Mvc;
using MyProjectAds;
using WebAds.Models;

namespace WebAds.Controllers
{
    public class PageController : Controller
    {
        public static AdsBusiness _ads { get; set; }
        public static List<Ad> Favorites = new List<Ad>();

        public IActionResult Index()
        {
            _ads = new AdsBusiness();

            return View(_ads.Page.Ads);
        }

        public IActionResult ListByPriceDesc()
        {
            var ordered = _ads.ListByPriceDesc();

            return View("Index", ordered);
        }

        public IActionResult ListByDateDesc()
        {
            var ordered = _ads.ListByDateDesc();

            return View("Index", ordered);
        }

        public IActionResult ListByPriceAsc()
        {
            var ordered = _ads.ListByPriceAsc();

            return View("Index", ordered);
        }

        public IActionResult Details(int adId)
        {
            var found = _ads.GetById(adId);

            if (found != null)
            {
                return View(found);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult AddToFavorites(int id)
        {
            var found = _ads.GetById(id);
            if(found != null)
            {
                Favorites.Add(found);
            }

            return RedirectToAction("ViewFavorites");
        }

        public IActionResult RemoveFavoriteAd(int adId)
        {
            var foundFavorite = Favorites.Find(a => a.Id == adId);
            if (foundFavorite != null)
            {
                Favorites.Remove(foundFavorite);
            }
            return RedirectToAction("ViewFavorites");
        }

        public IActionResult ViewFavorites()
        {
            return View("Favorites", Favorites);
        }

        [HttpPost]
        public IActionResult FilterByPrice(double fromPrice, double toPrice)
        {
            var filtered = _ads.FilterByPrice(fromPrice, toPrice);
            return View("Index", filtered);
        }

        [HttpPost]
        public IActionResult Search(string criteria)
        {
            var filtered = _ads.Search(criteria);

            return View("Index", filtered);
        }
    }
}