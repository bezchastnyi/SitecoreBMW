﻿using Feature.Product.Constants;
using Feature.Product.Models;
using System.Web.Mvc;

namespace Feature.Product.Controllers
{
    public class ProductBannerController : Controller
    {
        public ActionResult Index()
        {
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