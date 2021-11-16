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
        var logged = UserMaintenance.LoginAsUser(user.UserName, user.Password, true);
        return View($"~/Views/AuthenticationResult/authenticationResult.cshtml", 
          new AuthenticationResult { Type = AuthenticationType.Logging, Result = logged});
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error(
          $"Error in {ServiceName}-{nameof(Login)}: " +
          $"Message: {ex.Message}; Source:{ex.Source}; User Name: {user.UserName}", this);

        return new EmptyResult();
      }
    }
    
    public ActionResult Logout()
    {
      try
      {
        UserMaintenance.Logout();
        return new EmptyResult();
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error(
          $"Error in {ServiceName}-{nameof(Login)}: Message: {ex.Message}; Source:{ex.Source}", this);

        return new EmptyResult();
      }
    }
  }
}