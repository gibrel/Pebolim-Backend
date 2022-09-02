using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pebolim.Domain.Entities;

namespace Pebolim.Data.Mapping
{
    public class UserProfileMap : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfile");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasConversion(p => p.ToString(), p => p)
                .IsRequired()
                .HasColumnName("ProfileName")
                .HasColumnType("varchar(100)");

            builder.HasOne(p => p.User)
                .WithMany(u => u.UserProfiles)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(p => p.Team)
                .WithOne(t => t.UserProfile)
                .HasForeignKey<Team>(t => t.UserProfileId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
