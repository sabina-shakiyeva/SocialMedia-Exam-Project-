using Social.Project.DAL.Context;
using Social.Project.Models.Entities.Concrete;

namespace Social.Project.DAL.Repositories.Concrete
{
    public class UserDetailsRepository : BaseRepository<UserDetails>
    {
        public UserDetailsRepository(SocialDbContext context) : base(context)
        {
        }
    }
}
