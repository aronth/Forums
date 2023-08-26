using System.ComponentModel.DataAnnotations;

public class User
{

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = "";

    public string Password { get; set; } = "";
}