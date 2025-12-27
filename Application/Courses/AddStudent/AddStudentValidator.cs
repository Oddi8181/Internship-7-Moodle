

using Application.Common.Validation;

namespace Application.Courses.AddStudent
{
    public class AddStudentValidator
    {
        public ValidationResult Validate(AddStudentCommand command)
        {
            var result = new ValidationResult();
            if (command.CourseId == Guid.Empty)
            {
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "CourseId is required.",
                    Code = "COURSE_ID_REQUIRED"
                });
            }
            if (command.StudentId == Guid.Empty)
            {
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "StudentId is required.",
                    Code = "STUDENT_ID_REQUIRED"
                });
            }
            return result;
        }
    }
}
