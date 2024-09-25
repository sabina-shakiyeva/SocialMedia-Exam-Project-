using Microsoft.EntityFrameworkCore;
using Social.Project.Models.Entities.Concrete;

namespace Social.Project.DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.UserDetails)
              .WithOne()
              .HasForeignKey<User>(u => u.UserDetailsId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u=>u.Posts)
                .WithOne(p=>p.User)
                .HasForeignKey(p=>p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
