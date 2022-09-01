using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pebolim.Domain.Entities;

namespace Pebolim.Data.Mapping
{
    public class TeamMap : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Team");

            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.UserProfile)
                .WithOne(p => p.Team)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
