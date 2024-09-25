using Social.Project.Models.Entities.Abstract;

namespace Social.Project.Models.Entities.Concrete;

public class User:BaseEntity
{
    public int Id { get; set; }
    public UserDetails UserDetails { get; set; }
    public int UserDetailsId { get; set; }
    public ICollection<Post> Posts { get; set; }
}
