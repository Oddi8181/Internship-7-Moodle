using Domain.Entities;

namespace Application.Courses.AddMaterial
{
    public interface IStudyMaterialRepository
    {
        Task AddAsync(StudyMaterial material);
    }
}