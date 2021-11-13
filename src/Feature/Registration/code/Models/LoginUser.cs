namespace Feature.Authentication.Models
{
  public class LoginUser
  {
    public string UserName { get; set; }
    
    public string Password { get; set; }

    public bool Persistent => Remember == "on";

    private string Remember { get; set; }
  }
}