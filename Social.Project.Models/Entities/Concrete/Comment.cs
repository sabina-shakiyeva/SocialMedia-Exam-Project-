using Social.Project.Models.Entities.Abstract;

namespace Social.Project.Models.Entities.Concrete;

public class Comment:BaseEntity
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int LikeCount { get; set; }
    public int PostId { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Post> Posts { get; set; }
}
