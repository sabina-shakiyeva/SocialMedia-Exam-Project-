using Social.Project.Models.Entities.Abstract;

namespace Social.Project.Models.Entities.Concrete;

public class UserDetails:BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    public Role Role { get; set; }

}
