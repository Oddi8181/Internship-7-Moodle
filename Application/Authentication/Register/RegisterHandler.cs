using Application.Authentication.Login;
using Application.Common.Model;
using Application.Common.Validation;
using Domain.Entities;
using Domain.Persistance;

namespace Application.Authentication.Register
{
    public class RegisterHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly RegisterValidator _validator;
        public RegisterHandler(IUserRepository userRepository, RegisterValidator validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }
        public async Task<Result<User>> HandleAsync(RegisterCommand command)
        {
            var validation = _validator.Validate(command);
            if (validation.HasErrors)
            {
                return Result<User>.Failure(validation);
            }

            if (await _userRepository.ExistsByEmailAsync(command.Email))
                return EmailAlreadyExists();

            var passwordHash = PasswordHasher.Hash(command.Password);

            var user = new User(command.Email, passwordHash);

            await _userRepository.AddAsync(user);
            return Result<User>.Success(user);

        }

        private Result<User> EmailAlreadyExists()
        {
            var validation = new ValidationResult();
            validation.AddValidationItem(new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                Message = "Email already exists.",
                Code = "EMAIL_EXISTS"
            });
            return Result<User>.Failure(validation);
        }
    }
}
