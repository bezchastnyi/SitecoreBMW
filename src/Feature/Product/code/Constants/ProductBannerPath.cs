using System.Collections.Generic;

namespace Feature.Product.Constants
{
    public static class ProductBannerPath
    {
        public static Dictionary<string, string> BannerPath { get; set; } = new Dictionary<string, string>
        {
          ["BMW M8 Cabrio"] = "../../../wwwroot/BMW_M8_Cabrio.mp4",
          ["BMW 8-series Gran Coupe"] = "../../../wwwroot/BMW_8_Series_Gran_Coupe.mp4",
          ["BMW M8"] = "../../../wwwroot/BMW_M8.mp4",
        };
      }
}
