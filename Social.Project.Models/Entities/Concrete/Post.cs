using Social.Project.Models.Entities.Abstract;

namespace Social.Project.Models.Entities.Concrete;

public class Post:BaseEntity
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public string? Comment { get; set; }
    public int LikeCount { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<Comment> Comments { get; set; }
}
