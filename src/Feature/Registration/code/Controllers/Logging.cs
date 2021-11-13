using System;
using System.Web.Mvc;
using Feature.Authentication.Models;
using Feature.Authentication.Services;

namespace Feature.Authentication.Controllers
{
  public class Logging : Controller
  {
    private const string ServiceName = "Feature.Authentication.Controllers.Logging";
    
    public ActionResult Login()
    {
      return View();
    }
    
    [HttpPost]
    public ActionResult Login(LoginUser user)
    {
      try
      {
        var userMaintenance = new UserMaintenance();
        var logged = userMaintenance.LoginAsUser(user.UserName, user.Password, true);
        return new EmptyResult();
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error(
          $"Error in {ServiceName}-{nameof(Login)}: " +
          $"Message: {ex.Message}; Source:{ex.Source}; User Name: {user.UserName}", this);

        return new EmptyResult();
      }
      
      /*
       var user = AuthenticationManager.GetActiveUser();
      
      var userMaintenance = new UserMaintenance();
      var result = userMaintenance.LoginAsUser("admin", "b", true);
      
      
      //var result = AuthenticationManager.Login(userName, "b", true);
      //AuthenticationManager.SetActiveUser(userName);
       */
    }
  }
}