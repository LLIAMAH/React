using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using React.DB.Entities;

namespace React.DB.Configurations;

public class StatusesConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasData([
            new Status() { Id = 1, Name = "Pending" },
            new Status() { Id = 2, Name = "Development" },
            new Status() { Id = 3, Name = "QA" },
            new Status() { Id = 4, Name = "Completed" }
        ]);
    }
}