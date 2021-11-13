namespace Feature.Authentication.Models
{
  public class RegisterUser
  {
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }

    public string Domain { get; set; }
    
    public string Comment { get; set; }
    
    public string Password { get; set; }
  }
}