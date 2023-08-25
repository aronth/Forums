using Microsoft.EntityFrameworkCore.DataAnnotations;

public class Post {

    [Key]
    public Guid Id {get; set;}= Guid.NewGuid();

    public User User {get; set;}

    public string PostText {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

    public DateTime UpdatedAt {get; set;} = DateTime.UtcNow;

    public bool IsEdited {get; set;} = false;

    public bool IsDeleted {get; set;} = false;

    public bool IsPinned {get; set;} = false;

    public string OriginalPost {get; set;}

    public int Likes {get; set;} = 0;

    public int Dislikes {get; set;} = 0;
}