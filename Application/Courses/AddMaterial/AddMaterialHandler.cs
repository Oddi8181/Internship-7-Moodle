using Application.Common.Model;
using Application.Common.Validation;
using Domain.Entities;
using Domain.Persistance;

namespace Application.Courses.AddMaterial
{
    public class AddMaterialHandler
    {
        public class AddStudyMaterialHandler
        {
            private readonly ICourseRepository _courseRepository;
            private readonly IStudyMaterialRepository _studyMaterialRepository;

            public AddStudyMaterialHandler(
                ICourseRepository courseRepository,
                IStudyMaterialRepository studyMaterialRepository)
            {
                _courseRepository = courseRepository;
                _studyMaterialRepository = studyMaterialRepository;
            }

            public async Task<Result<Guid>> Handle(AddMaterialCommand command)
            {

                var validator = new AddMaterialValidator();
                var validation = validator.Validate(command);

                if (validation.HasErrors)
                {
                    return Result<Guid>.Failure(validation);
                }


                var course = await _courseRepository.GetByIdAsync(command.CourseId);

                if (course == null)
                {
                    validation.AddValidationItem(new ValidationItem
                    {
                        ValidationSeverity = ValidationSeverity.Error,
                        Message = "Course not found",
                        Code = "COURSE_NOT_FOUND"
                    });

                    return Result<Guid>.Failure(validation);
                }


                var material = new StudyMaterial(
                    command.Name,
                    command.Url,
                    course
                );


                await _studyMaterialRepository.AddAsync(material);


                return Result<Guid>.Success(material.Id);
            }
        }
    }
}
