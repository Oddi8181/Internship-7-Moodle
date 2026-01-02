namespace Application.Admin.UpdateUserEmail
{
    public class UpdateUserEmailCommand
    {
        public Guid AdminId { get; init; }
        public Guid UserId { get; init; }
        public string NewEmail { get; init; }s
    }
}
