namespace Feature.Authentication.Models
{
  public class AuthenticationResult
  {
    public AuthenticationType Type { get; set; }
      
    public bool Result { get; set; }
  }
  
  public enum AuthenticationType
  {
    Logging,
    Registration
  }
}