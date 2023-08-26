using Microsoft.EntityFrameworkCore.DataAnnotations;

public class Section {

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Topic> Topics { get; set; }

}