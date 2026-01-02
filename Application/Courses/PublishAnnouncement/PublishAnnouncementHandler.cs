using Application.Common.Model;
using Application.Common.Validation;

namespace Application.Courses.PublishAnnouncement
{
    public class PublishAnnouncementHandler
    {
        private readonly Domain.Persistance.ICourseRepository _courseRepository;
        private readonly PublishAnnouncementValidator _validator;
        public PublishAnnouncementHandler(Domain.Persistance.ICourseRepository courseRepository,
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
            if (course.ProffesorId != command.ProffesorId)
                return Forbidden();

            course.AddNotification(command.Title, command.Content);

            await _courseRepository.UpdateAsync(course);

            return Result<bool>.Success(true);
        }

        private Result<bool> Forbidden()
           => Error("FORBIDDEN", "You are not the professor of this course");
      
        private Result<bool> NotFound(string v1, string v2)
            => Error(v1, v2);
    
        private Result<bool> Error(string v1, string v2)
        {
            var validation = new ValidationResult();
            validation.AddValidationItem(new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                Message = v2,
                Code = v1
            });
            return Result<bool>.Failure(validation);
        }


    }
}