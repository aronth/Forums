using System.ComponentModel.DataAnnotations;

public class UserRegisterRequest
{
    [Required]
    public String Username { get; set; }
    [Required]
    public String Password { get; set; }
}