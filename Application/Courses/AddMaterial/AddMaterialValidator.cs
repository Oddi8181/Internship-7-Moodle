using Application.Common.Validation;
using Domain.Entities;

namespace Application.Courses.AddMaterial
{
    public class AddMaterialValidator
    {
        public ValidationResult Validate(AddMaterialCommand command)
        {   
            var result = new ValidationResult();
            if(command.CourseId == Guid.Empty)
            {
                result.AddValidationItem(new ValidationItem {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "CourseId is required.",
                    Code = "COURSE_ID_REQUIRED"
                });
            }
            if(command.ProfessorId == Guid.Empty)
            {
                result.AddValidationItem(new ValidationItem {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "ProfessorId is required.",
                    Code = "PROFESSOR_ID_REQUIRED"
                });
            }
            if(string.IsNullOrWhiteSpace(command.Name))
            {
                result.AddValidationItem(new ValidationItem {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "MaterialTitle is required.",
                    Code = "MATERIAL_TITLE_REQUIRED"
                });
            }

            if(command.Url == string.Empty)
            {
                result.AddValidationItem(new ValidationItem {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "MaterialUrl is required.",
                    Code = "MATERIAL_URL_REQUIRED"
                });
            }
            if (!IsValidUrl(command.Url))
            {
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "MaterialUrl is not a valid URL.",
                    Code = "MATERIAL_URL_INVALID"
                });
            }
            return result;
        }

        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
