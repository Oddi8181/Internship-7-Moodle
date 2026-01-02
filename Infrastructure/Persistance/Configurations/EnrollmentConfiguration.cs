using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.ToTable("enrollments");

        builder.HasKey(x => new { x.UserId, x.CourseId });

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.CourseId)
            .IsRequired();
    }
}

