namespace Application.Admin.DeleteUser
{
    public class DeleteUserCommand
    {
        public Guid UserId { get; init; }
        public Guid AdminId { get; init; }
    }
}
