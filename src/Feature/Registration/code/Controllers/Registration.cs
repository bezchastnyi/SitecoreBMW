using System;
using System.Web.Mvc;
using Feature.Authentication.Models;
using Feature.Authentication.Services;

namespace Feature.Authentication.Controllers
{
  public class Registration : Controller
  {
    private const string ServiceName = "Feature.Authentication.Controllers.Registration";
    
    public ActionResult Register()
    {
      return View();
    }
    
    [HttpPost]
    public ActionResult Register(RegisterUser user)
    {
      // TODO do not hardcore domain
      user.Domain = "BMW";
      var userName = string.Empty;
      
      try
      {
        userName = UserMaintenance.AddNewUser(
          user.Domain, user.FirstName, user.LastName, user.Email, user.Comment, user.Password);

        var logged = false;
        if (!string.IsNullOrEmpty(userName))
        {
          UserMaintenance.AssignUserToRole(user.Domain, user.FirstName, user.LastName, false);
          logged = UserMaintenance.LoginAsUser(
            user.Domain, user.FirstName, user.LastName, user.Password, true);
        }

        return View($"~/Views/AuthenticationResult/authenticationResult.cshtml", 
          new AuthenticationResult { Type = AuthenticationType.Registration, Result = logged});
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error(
          $"Error in {ServiceName}-{nameof(Register)}: " +
          $"Message: {ex.Message}; Source:{ex.Source}; User Name: {userName}", this);

        return new EmptyResult();
      }
    }
  }
}