using Microsoft.EntityFrameworkCore;
using Social.Project.DAL.Context;
using Social.Project.Models.Entities.Concrete;

namespace Social.Project.DAL.Repositories.Concrete
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(SocialDbContext context) : base(context)
        {
        }
    }
}
