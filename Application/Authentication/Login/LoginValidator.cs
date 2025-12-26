using Application.Common.Validation;

namespace Application.Authentication.Login
{
    public class LoginValidator
    {
        public  ValidationResult Validate(LoginCommand command) //make static if needed
        {
            var result = new ValidationResult();
            if (string.IsNullOrWhiteSpace(command.Email))
            {
               result.AddValidationItem(new ValidationItem {
                   ValidationSeverity = ValidationSeverity.Error,
                   Message = "Email is required.",
                   Code = "EMAIL_REQUIRED"
                   });
            }
            if (string.IsNullOrWhiteSpace(command.Password))
            {
               result.AddValidationItem(new ValidationItem {
                   ValidationSeverity = ValidationSeverity.Error,
                   Message = "Password is required.",
                   Code = "PASSWORD_REQUIRED"
                   });
            }
            return result;
        }
    }
}
