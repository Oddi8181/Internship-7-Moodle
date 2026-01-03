using Application.Common.Model;
using Application.Common.Validation;
using Domain.Entities;
using Domain.Enums;
using Domain.Persistance;

namespace Application.Courses.Add
{
    public class AddCourseHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;

        public AddCourseHandler(
            IUserRepository userRepository,
            ICourseRepository courseRepository)
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
        }

        public async Task<Result<Guid>> Handle(AddCourseCommand command)
        {
            var validation = new ValidationResult();

            var professor = await _userRepository.GetByIdAsync(command.ProfessorId);
            if (professor == null || professor.Role != Role.Professor)
            {
                validation.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Invalid professor",
                    Code = "INVALID_PROFESSOR"
                });
                return Result<Guid>.Failure(validation);
            }

            var course = new Course(command.Name, professor);
            await _courseRepository.AddAsync(course);

            return Result<Guid>.Success(course.Id);
        }
    }
}
