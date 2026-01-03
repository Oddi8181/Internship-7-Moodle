using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("courses");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            
            builder.HasOne(c => c.Professor)
                .WithMany(u => u.Courses)
                .HasForeignKey(c => c.ProfessorId);

           
            builder.HasMany(c => c.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId);

            
            builder.HasMany(c => c.StudyMaterials)
                .WithOne(sm => sm.Course)
                .HasForeignKey(sm => sm.CourseId);

            
            builder.HasMany(c => c.Notifications)
                .WithOne(n => n.Course)
                .HasForeignKey(n => n.CourseId);
        }
    }
}
