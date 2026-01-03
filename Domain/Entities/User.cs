using Domain.Entities;
using Domain.Enums;

public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public Role Role { get; private set; }

    public ICollection<Enrollment> Enrollments { get; private set; } = new List<Enrollment>();
    public ICollection<Course> Courses { get; private set; } = new List<Course>();
    public ICollection<PrivateMessage> SentMessages { get; private set; } = new List<PrivateMessage>();
    public ICollection<PrivateMessage> ReceivedMessages { get; private set; } = new List<PrivateMessage>();

   
    private User() { }

    
    public User(string firstName, string lastName, string email, string passwordHash, Role role)
    {
        Id = Guid.NewGuid();
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
        Role = role;
      
    }

    public User(string email, string passwordHash)
    {
        Email = email;
        PasswordHash = passwordHash;
    }

    public void ChangeRole(Role newRole) => Role = newRole;

    public void UpdateEmail(string newEmail) => Email = newEmail ?? throw new ArgumentNullException(nameof(newEmail));
}
