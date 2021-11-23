using System.Collections.Generic;

namespace Feature.Header
{
  public static class Constants
  {
    public static readonly List<string> MissingItems = new List<string>
    {
      "Authentication",
      "Terms And Privacy Policy",
      "Products By Country"
    };
    
    #region Items

    // BMW item
    public const string BMWItem = "/sitecore/Content/BMW";
    
    // Registration item
    public const string RegistrationItem = "/sitecore/Content/BMW/Authentication/Registration";
    
    // Logging item
    public const string LoggingItem = "/sitecore/Content/BMW/Authentication/Logging";

    #endregion

    #region Fields

    // Page Title
    public const string PageTitleField = "Page Title";
    
    // Header logo Title
    public const string HeaderLogoField = "Header Logo";

    #endregion
  }
}