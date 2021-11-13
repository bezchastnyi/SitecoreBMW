using Feature.Product.Constants;
using Feature.Product.Models;
using System.Web.Mvc;

namespace Feature.Product.Controllers
{
    public class ProductBannerController : Controller
    {
        public ActionResult Index()
        {
          /*var m = new UserMaintenance();
          m.AddUser(
            "Rita", "Kakashka", "last", "email", "com", "380", "adm");*/
          
            var sitecoreItem = Sitecore.Context.Item;
            var result = ProductBannerPath.BannerPath.TryGetValue(sitecoreItem.Fields["Mark"].Value, out var path);
            if (!result)
            {
              path = "not found";
            }

            return View(new ProductBanner { BannerPath = path });
        }
    }
}