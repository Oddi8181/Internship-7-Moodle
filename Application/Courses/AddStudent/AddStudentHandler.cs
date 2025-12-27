using Application.Common.Model;
using Application.Common.Validation;
using Domain.Persistance;


namespace Application.Courses.AddStudent
{
    public class AddStudentHandler
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;
        private readonly AddStudentValidator _validator;
        public async Task<Result<bool>>  HandleAsync(AddStudentCommand command)
        {
            var validation = _validator.Validate(command);
            if (validation.HasErrors)
            {
                return Result<bool>.Failure(validation);
            }
            var course = await _courseRepository.GetByIdAsync(command.CourseId);
            if (course == null)
                return NotFound("STUDENT_NOT_FOUND","Course not found");

            var student = await _userRepository.GetByIdAsync(command.StudentId);
            if (student == null)
                return NotFound("STUDENT_NOT_FOUND","Student not found");

            if (course.Enrollments.Any(e => e.UserId == student.Id))
                return AlreadyEnrolled();

            course.AddStudent(student);

            return Result<bool>.Success(true);
        }

        private Result<bool> AlreadyEnrolled()
        {
            var validation = new ValidationResult();
            validation.AddValidationItem(new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                Code = "ALREADY_ENROLLED",
                Message = "Student is already enrolled in the course."
            });
            return Result<bool>.Failure(validation);
        }

        private Result<bool> NotFound(string code, string message)
        {
            var validation = new ValidationResult();
            validation.AddValidationItem(new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                Code = code,
                Message = message
            });
            return Result<bool>.Failure(validation);
        }
    }
}
