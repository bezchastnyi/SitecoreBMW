using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Feature.Product.Constants;
using Sitecore.Data.Items;

namespace Feature.Product.Controllers
{
  public class ProductsByCountryController : Controller
  {
    public ActionResult Index()
    {
      var renderingContext = Sitecore.Mvc.Presentation.RenderingContext.CurrentOrNull;
      if (renderingContext == null)
      {
        // TODO make valid response
        return new EmptyResult();
      }

      var countryParameter = renderingContext.Rendering.Parameters["country"];
      
      var allProductsItem = Sitecore.Context.Database.Items.GetItem(ItemConstants.AllProducts);
      var products = new List<Item>(allProductsItem.Children);
      var productsByCountry = products.Where(product => 
        product.Fields["Country"].Value.Contains(countryParameter)).ToList();

      return View(productsByCountry.OrderByDescending(x => x.Fields["Year"].Value).ToList());
    }
  }
}