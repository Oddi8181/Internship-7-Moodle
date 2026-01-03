using Application.Common.Validation;
using System.Text.RegularExpressions;

namespace Application.Authentication.Register
{
    public class RegisterValidator
    {
        public static ValidationResult Validate(RegisterCommand command)
        {
            var result = new ValidationResult();
            if (string.IsNullOrWhiteSpace(command.FirstName))
            {
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Name is required.",
                    Code = "NAME_REQUIRED"
                });
            }
            if (string.IsNullOrWhiteSpace(command.LastName))
            {
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Name is required.",
                    Code = "NAME_REQUIRED"
                });
            }
            if (string.IsNullOrWhiteSpace(command.Email))
            {
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Email is required.",
                    Code = "EMAIL_REQUIRED"
                });
            }
            if (string.IsNullOrWhiteSpace(command.Password))
            {
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Password is required.",
                    Code = "PASSWORD_REQUIRED"
                });
            }
            if (command.Password != command.RepeatPassword)
            {
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Passwords do not match.",
                    Code = "PASSWORDS_MISMATCH"
                });
            }
            if (command.Captcha != command.ExpectedCaptcha)
            {
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Invalid captcha.",
                    Code = "INVALID_CAPTCHA"
                });
            }
            if (!IsValidEmail(command.Email))
            {
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Invalid email format.",
                    Code = "INVALID_EMAIL_FORMAT"
                });
            }
            return result;
        }

        private static bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^.{1,}@.{2,}\..{3,}$");
            return regex.IsMatch(email);
        }
    }
}
