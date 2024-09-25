using Microsoft.EntityFrameworkCore;
using Social.Project.DAL.Configuration;
using Social.Project.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Project.DAL.Context
{
    public class SocialDbContext:DbContext
    {
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            object value = optionsBuilder.UseSqlServer("Data Source=LAPTOP-KBFH69R7;Initial Catalog=SocialMediaDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new UserDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}