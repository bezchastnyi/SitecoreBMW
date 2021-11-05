using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Feature.Product.Controllers
{
  public class GermanProductsController : Controller
  {
    public ActionResult Index()
    {
      var allProductsItem = Sitecore.Context.Database.Items.GetItem("/sitecore/Content/BMW/All Products");
      var products = new List<Item>(allProductsItem.Children);
      var germanProducts = new List<Item>();

      foreach (var product in products)
      {
        if (product.Fields["Country"].Value.Contains("Germany"))
        {
          germanProducts.Add(product);
        }
      }

      return View(germanProducts.OrderByDescending(x => x.Fields["Year"].Value).ToList());
    }
  }
}