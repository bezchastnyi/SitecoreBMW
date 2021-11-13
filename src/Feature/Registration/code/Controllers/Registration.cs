﻿using System;
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
        var userMaintenance = new UserMaintenance();
        userName = userMaintenance.AddNewUser(
          user.Domain, user.FirstName, user.LastName, user.Email, user.Comment, user.Password);
        return new EmptyResult();
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