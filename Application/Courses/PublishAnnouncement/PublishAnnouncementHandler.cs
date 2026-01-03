using Application.Common.Model;
using Application.Common.Validation;
using Domain.Entities;
using Domain.Persistance;

namespace Application.Courses.PublishAnnouncement
{
    public class PublishAnnouncementHandler
    {
        private readonly ICourseRepository _courseRepository;
        private readonly PublishAnnouncementValidator _validator;

        public PublishAnnouncementHandler(
            ICourseRepository courseRepository,
            PublishAnnouncementValidator validator)
        {
            _courseRepository = courseRepository;
            _validator = validator;
        }

        public async Task<Result<bool>> HandleAsync(PublishAnnouncementCommand command)
        {
            var validationResult = _validator.Validate(command);
            if (validationResult.HasErrors)
                return Result<bool>.Failure(validationResult);

            var course = await _courseRepository.GetByIdAsync(command.CourseId);
            if (course is null)
                return NotFound("COURSE_NOT_FOUND", "Course not found");

            if (course.ProfessorId != command.ProfessorId)
                return Forbidden();

            course.AddNotification(command.Title, command.Content);

            await _courseRepository.UpdateAsync(course);

            return Result<bool>.Success(true);
        }

        private Result<bool> Forbidden()
            => Error("FORBIDDEN", "You are not the professor of this course");

        private Result<bool> NotFound(string code, string message)
            => Error(code, message);

        private Result<bool> Error(string code, string message)
        {
            var validation = new ValidationResult();
            validation.AddValidationItem(new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                Message = message,
                Code = code
            });

            return Result<bool>.Failure(validation);
        }
    }
}
