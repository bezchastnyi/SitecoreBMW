using System.Collections.Generic;

namespace Feature.Footer
{
  public static class Constants
  {
    public static readonly List<string> MissingItems = new List<string>
    {
      "Authentication",
    };
    
    #region Items

    // BMW item
    public const string BMWItem = "/sitecore/Content/BMW";

    #endregion

    #region Fields

    // Page Title
    public const string PageTitleField = "Page Title";
    
    // Footer logo
    public const string FooterLogoField = "Footer Logo";
    
    // Footer text
    public const string FooterTextField = "Footer Text";

    #endregion
  }
}