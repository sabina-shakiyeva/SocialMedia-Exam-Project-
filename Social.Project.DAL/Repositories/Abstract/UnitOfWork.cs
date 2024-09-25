using Social.Project.DAL.Context;
using Social.Project.DAL.Repositories.Concrete;
using Social.Project.Models.Entities.Concrete;

namespace Social.Project.DAL.Repositories.Abstract
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly SocialDbContext _context;
        public IRepository<User> Users { get; set; }
        public IRepository<Comment> Comments { get; set; }
        public IRepository<Post> Posts { get; set; }
        public IRepository<UserDetails> UserDetails { get; set; }

        public UnitOfWork(SocialDbContext context)
        {
            _context = context;
            Posts = new BaseRepository<Post>(_context);
            Comments = new BaseRepository<Comment>(_context);
            Users = new BaseRepository<User>(_context);
            UserDetails = new BaseRepository<UserDetails>(_context);

        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
