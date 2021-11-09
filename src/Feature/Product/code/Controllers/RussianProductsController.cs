using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;

namespace Feature.Product.Controllers
{
  public class RussianProductsController : Controller
  {
    public ActionResult Index()
    {
      var allProductsItem = Sitecore.Context.Database.Items.GetItem("/sitecore/Content/BMW/All Products");
      var products = new List<Item>(allProductsItem.Children);
      var russianProducts = new List<Item>();

      foreach (var product in products)
      {
        if (product.Fields["Country"].Value.Contains("Россия"))
        {
          russianProducts.Add(product);
        }
      }

      ID contextLanguageId = LanguageManager.GetLanguageItemId(Sitecore.Context.Language, Sitecore.Context.Database);
      Item contextLanguage = Sitecore.Context.Database.GetItem(contextLanguageId);

      return View(russianProducts.OrderByDescending(x => x.Fields["Year"].Value).ToList());
    }
  }
}