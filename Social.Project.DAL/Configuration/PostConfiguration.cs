using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Social.Project.Models.Entities.Concrete;

namespace Social.Project.DAL.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p=>p.Id);


            builder.Property(p => p.Text)
               .HasMaxLength(500);

            builder.Property(p => p.LikeCount)
              .HasDefaultValue(0);

            builder.Property(p => p.Comment)
                   .HasMaxLength(400);

            builder.HasOne(p => p.User)
              .WithMany(u => u.Posts)
              .HasForeignKey(p => p.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Comments)
              .WithMany(c => c.Posts);

        }
    }
}
