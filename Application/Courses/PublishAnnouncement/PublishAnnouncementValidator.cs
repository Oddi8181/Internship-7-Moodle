
using Application.Common.Validation;



namespace Application.Courses.PublishAnnouncement
{
    public class PublishAnnouncementValidator
    {
        public ValidationResult Validate(PublishAnnouncementCommand command)
        {
            var result = new ValidationResult();

            if (command.CourseId == Guid.Empty)
                AddError(result, "CourseId is required", "COURSE_ID_REQUIRED");

            if (string.IsNullOrWhiteSpace(command.Title))
                AddError(result, "Title is required", "TITLE_REQUIRED");

            if (string.IsNullOrWhiteSpace(command.Content))
                AddError(result, "Content is required", "CONTENT_REQUIRED");

            return result;
        }
        private static void AddError(
            ValidationResult result,
            string message,
            string code)
        {
            result.AddValidationItem(new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                Message = message,
                Code = code
            });
        }
    }
}
