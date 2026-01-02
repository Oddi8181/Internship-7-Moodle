using Application.Common.Validation;
using System.Text.RegularExpressions;

namespace Application.Admin.UpdateUserEmail
{
    public class UpdateUserEmailValidator
    {
        public ValidationResult Validate(UpdateUserEmailCommand command)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(command.NewEmail))
                AddError(result, "Email is required", "EMAIL_REQUIRED");

            if (!Regex.IsMatch(command.NewEmail, @"^.{1,}@.{2,}\..{3,}$"))
                AddError(result, "Invalid email format", "EMAIL_INVALID");

            return result;
        }

        private void AddError(ValidationResult r, string m, string c)
        {
            r.AddValidationItem(new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                Message = m,
                Code = c
            });
        }
    }
}
