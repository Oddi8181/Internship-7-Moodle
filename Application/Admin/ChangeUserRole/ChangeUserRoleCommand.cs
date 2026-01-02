using Domain.Enums;

namespace Application.Admin.ChangeUserRole
{
    public class ChangeUserRoleCommand
    {
        public Guid AdminId { get; init; }
        public Guid UserId { get; init; }
        public Role NewRole { get; init; }
    }
}
