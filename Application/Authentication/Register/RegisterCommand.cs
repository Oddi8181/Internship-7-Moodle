namespace Application.Authentication.Register
{
    public class RegisterCommand
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string RepeatPassword { get; init; } 
        public string Captcha { get; init; }
        public string ExpectedCaptcha { get; init; }
    }
}
