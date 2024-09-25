using Social.Project.DAL.Context;
using Social.Project.Models.Entities.Concrete;

namespace Social.Project.DAL.Repositories.Concrete
{
    public class PostRepository : BaseRepository<Post>
    {
        public PostRepository(SocialDbContext context) : base(context)
        {
        }
    }
}
