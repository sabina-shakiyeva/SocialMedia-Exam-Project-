using Social.Project.DAL.Context;
using Social.Project.Models.Entities.Concrete;

namespace Social.Project.DAL.Repositories.Concrete
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(SocialDbContext context) : base(context)
        {

        }
    }
}
