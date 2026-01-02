using Application.Common.Model;
using Application.Common.Validation;
using Domain.Enums;
using Domain.Persistance;

namespace Application.Admin.UpdateUserEmail
{
    public class UpdateUserEmailHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly UpdateUserEmailValidator _validator;

        public UpdateUserEmailHandler(
            IUserRepository userRepository,
            UpdateUserEmailValidator validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<Result<bool>> HandleAsync(UpdateUserEmailCommand command)
        {
            var validation = _validator.Validate(command);
            if (validation.HasErrors)
                return Result<bool>.Failure(validation);

            var admin = await _userRepository.GetByIdAsync(command.AdminId);
            if (admin == null || admin.Role != Role.Admin)
                return Forbidden();

            if (await _userRepository.ExistsByEmailAsync(command.NewEmail))
                return EmailExists();

            var user = await _userRepository.GetByIdAsync(command.UserId);
            if (user == null)
                return NotFound();

            user.UpdateEmail(command.NewEmail);
            await _userRepository.UpdateAsync(user);

            return Result<bool>.Success(true);
        }

        private Result<bool> Forbidden() => Error("FORBIDDEN", "Admin only");
        private Result<bool> NotFound() => Error("USER_NOT_FOUND", "User not found");
        private Result<bool> EmailExists() => Error("EMAIL_EXISTS", "Email already exists");

        private Result<bool> Error(string code, string message)
        {
            var vr = new ValidationResult();
            vr.AddValidationItem(new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                Message = message,
                Code = code
            });
            return Result<bool>.Failure(vr);
        }
    }
}
