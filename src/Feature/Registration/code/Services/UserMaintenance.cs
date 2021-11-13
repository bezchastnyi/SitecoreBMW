﻿using System;
using System.Linq;
using System.Web.Security;
using Sitecore.Configuration;
using Sitecore.Security.Accounts;
using Sitecore.Security.Authentication;

namespace Feature.Authentication.Services
{
  public class UserMaintenance
  {
    private const string ServiceName = "Feature.Authentication.Services.UserMaintenance";

    #region User Edit Operations

    public string AddNewUser(
      string domain, string firstName, string lastName, string email, string comment, string password = null)
    {
      var userName = $@"{domain}\{firstName}{lastName}";
      if (string.IsNullOrEmpty(password))
      {
        password = Membership.GeneratePassword(10, 3);
      }
      
      try
      {
        if (User.Exists(userName))
        {
          return userName;
        }

        Membership.CreateUser(userName, password, email);

        // Edit the profile information
        var user = User.FromName(userName, true);
        var userProfile = user.Profile;
        userProfile.FullName = $"{firstName} {lastName}";
        userProfile.Comment = comment;

        // Assigning the user profile template
        userProfile.SetPropertyValue("ProfileItemId", "{AE4C4969-5B7E-4B4E-9042-B2D8701CE214}");

        //userProfile.SetCustomProperty("TelephoneNumber", telephoneNumber);
        userProfile.Save();
        return userName;
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error(
          $"Error in {ServiceName}-{nameof(AddNewUser)}: " +
          $"Message: {ex.Message}; Source:{ex.Source}; User Name: {userName}", this);
        return null;
      }
    }

    public bool UserExists(string userName) => User.Exists(userName);
    
    public bool UserExists(string domain, string firstName, string lastName)
    {
      var userName = $@"{domain}\{firstName}{lastName}";
      return User.Exists(userName);
    }

    public void EditUser(string domain, string firstName, string lastName, string email, string comment)
    {
      var userName = $@"{domain}\{firstName}{lastName}";
      
      try
      {
        // TODO check user existence
        var user = User.FromName(userName, true);
        var userProfile = user.Profile;
        if (!string.IsNullOrEmpty(email))
        {
          userProfile.Email = email;
        }

        if (!string.IsNullOrEmpty(comment))
        {
          userProfile.Comment = comment;
        }

        /*if (!string.IsNullOrEmpty(jobTitle))
        {
          userProfile.SetCustomProperty("JobTitle", jobTitle);
        }*/
        userProfile.Save();
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error(
          $"Error in {ServiceName}-{nameof(EditUser)}: " +
          $"Message: {ex.Message}; Source:{ex.Source}; User Name: {userName}", this);
      }
    }

    public void DeleteUser(string userName)
    {
      try
      {
        var user = User.FromName(userName, true);
        user.Delete();
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error(
          $"Error in {ServiceName}-{nameof(DeleteUser)}: " +
          $"Message: {ex.Message}; Source:{ex.Source}; User Name: {userName}", this);
      }
    }

    public void AssignUserToRole(string domain, string firstName, string lastName, bool isSuperUser)
    {
      var userName = $@"{domain}\{firstName}{lastName}";
      
      try
      {
        var userRolesConfig = ConfigStore.Load("config");
        var userRoles = userRolesConfig.RootRecord.GetChildRecords();
        
        var domainRole = isSuperUser 
          ? $"{domain}\\{userRoles.SingleOrDefault(role => role.Attributes["IsSuperUser"] == "1")?.Attributes["name"]}" 
          : $"{domain}\\{userRoles.SingleOrDefault(role => role.Attributes["IsSuperUser"] == "0" && role.Attributes["Access"] == "Allow")?.Attributes["name"]}";

        UserRoles.FromUser(User.FromName(userName, true)).Add(Role.FromName(domainRole));
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error(
          $"Error in {ServiceName}-{nameof(AssignUserToRole)}: " +
          $"Message: {ex.Message}; Source:{ex.Source}; User Name: {userName}", this);
      }
    }

    #endregion
    
    #region User Authentication Operations

    public bool LoginAsUser(string userName, string password, bool persistent)
    {
      if (!this.UserExists(userName))
      {
        return false;
      }

      try
      {
        return AuthenticationManager.Login(userName, password, persistent);
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error(
          $"Error in {ServiceName}-{nameof(AddNewUser)}: " +
          $"Message: {ex.Message}; Source:{ex.Source}; User Name: {userName}", this);
        return false;
      }
    }
    
    public static void Logout() => AuthenticationManager.Logout();

    #endregion
  }
}