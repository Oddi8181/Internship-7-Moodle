using Application.Common.Model;
using Application.Common.Validation;
using Domain.Entities;
using Domain.Persistance;

namespace Application.Authentication.Login
{
    public class LoginHandler
    {
       private readonly IUserRepository _userRepository;
       private readonly LoginValidator _validator;
       public LoginHandler(IUserRepository userRepository, LoginValidator validator)
         {
             _userRepository = userRepository;
             _validator = validator;
        }
        public async Task<Result<User>> HandleAsync(LoginCommand loginCommand)
        {
            var validation = _validator.Validate(loginCommand);
            if (validation.HasErrors)
            {
                return Result<User>.Failure(validation);
            }
            var user = await _userRepository.GetByEmailAsync(loginCommand.Email);

            if (user == null || !Application.Common.Validation.PasswordHasher.Verify(
        loginCommand.Password,
        user.PasswordHash))
                return InvalidCredentials();

            return Result<User>.Success(user);
        }

        private Result<User> InvalidCredentials()
        {
            var validation = new ValidationResult();
            validation.AddValidationItem(new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                Message = "Invalid email or password",
                Code = "INVALID_CREDENTIALS"
            });

            return Result<User>.Failure(validation);
        }
    }
}
