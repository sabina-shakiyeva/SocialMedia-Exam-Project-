using Social.Project.Models.Entities.Concrete;

namespace Social.Project.DAL.Repositories.Abstract
{
    public interface IUnitOfWork 
    {
        IRepository<Post> Posts { get; }
        IRepository<Comment> Comments { get; }
        IRepository<User> Users { get; }
        IRepository<UserDetails> UserDetails { get; }
        int Complete();
    }
}
