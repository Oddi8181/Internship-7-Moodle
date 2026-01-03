namespace Application.Authentication.Register
{
    public class RegisterCommand
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string RepeatPassword { get; init; } 
        public string Captcha { get; init; }
        public string ExpectedCaptcha { get; init; }
    }
}
