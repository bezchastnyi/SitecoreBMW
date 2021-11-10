using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;

namespace Feature.Product.Controllers
{
  public class ProductsByCountryController : Controller
  {
    public ActionResult Index()
    {
      var countryParameter = string.Empty;
      var renderingContext = Sitecore.Mvc.Presentation.RenderingContext.CurrentOrNull;
      if (renderingContext != null)
      {
        countryParameter = renderingContext.Rendering.Parameters["country"];
      }

      var allProductsItem = Sitecore.Context.Database.Items.GetItem("/sitecore/Content/BMW/All Products");
      var products = new List<Item>(allProductsItem.Children);
      var productsByCountry = products.Where(product => product.Fields["Country"].Value.Contains(countryParameter)).ToList();

      return View(productsByCountry.OrderByDescending(x => x.Fields["Year"].Value).ToList());
    }
  }
}