using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Social.Project.Models.Entities.Concrete;

namespace Social.Project.DAL.Configuration
{
    public class UserDetailsConfiguration : IEntityTypeConfiguration<UserDetails>
    {
       
        public void Configure(EntityTypeBuilder<UserDetails> builder)
        {
            builder.HasKey(ud => ud.Id);

            builder.Property(ud => ud.Name)
                .HasMaxLength(30);

            builder.Property(ud => ud.Surname)
              .HasMaxLength(30);

            //builder.Property(ud => ud.Birthday)
            //   .IsRequired();

            builder.Property(ud => ud.Role)
               .HasConversion<int>();
        }
    }
}
