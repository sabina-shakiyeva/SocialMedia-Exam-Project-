using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Social.Project.Models.Entities.Concrete;

namespace Social.Project.DAL.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>

{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c=>c.Id);

        builder.Property(c => c.Text)
            .HasMaxLength(400);
        builder.Property(c => c.LikeCount)
            .HasDefaultValue(0);
        builder.HasMany(c => c.Comments)
            .WithOne();
          
        builder.HasMany(c => c.Posts)
            .WithMany(p => p.Comments);
        
    }
}
