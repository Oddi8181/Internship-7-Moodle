using Application.Common.Model;
using Application.Common.Validation;
using Domain.Enums;
using Domain.Persistance;

namespace Application.Admin.DeleteUser
{
    public class DeleteUserHandler
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<bool>> Handle(DeleteUserCommand command)
        {
            var admin = await _userRepository.GetByIdAsync(command.AdminId);
            if (admin == null || admin.Role != Role.Admin)
                return Forbidden();

            var user = await _userRepository.GetByIdAsync(command.UserId);
            if (user == null)
                return NotFound();

            await _userRepository.DeleteAsync(user);

            return Result<bool>.Success(true);
        }

        private Result<bool> Forbidden()
            => Error("FORBIDDEN", "Only admin can delete users");

        private Result<bool> NotFound()
            => Error("USER_NOT_FOUND", "User not found");

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
