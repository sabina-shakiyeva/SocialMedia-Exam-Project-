using Microsoft.EntityFrameworkCore;
using Social.Project.DAL.Context;
using Social.Project.DAL.Repositories.Abstract;
using Social.Project.Models.Entities.Abstract;

namespace Social.Project.DAL.Repositories.Concrete
{
    public class BaseRepository<T> : IRepository<T> where T:BaseEntity,new()
    {
        private readonly SocialDbContext _context;
        private readonly DbSet<T> _dbSet;
        


        public BaseRepository(SocialDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            entity.CreatedDate = DateTime.Now;
        }

        public void Delete(int Id)
        {
            var entity = _dbSet.FirstOrDefault(e => e.Id == Id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                _dbSet.Remove(entity);
                entity.DeletedDate = DateTime.Now;
            }
            else
                throw new NullReferenceException();
        }

        public ICollection<T> GetAll()
        {
            return _dbSet.Where(x => x.IsDeleted == false).ToList();
        }

        public T GetById(int Id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == Id && x.IsDeleted == false);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(int Id)
        {
            var entity = _dbSet.FirstOrDefault(x => x.Id == Id);
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
    
}
