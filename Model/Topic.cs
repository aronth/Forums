using Microsoft.EntityFrameworkCore.DataAnnotations;

public class Topic {

    [Key]
    public Guid Id {get; set;} = Guid.NewGuid();

    public string Title {get; set;}

    public string Description {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;

    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public virtual ICollection<Post> Posts {get; set;} = new List<Post>();

}