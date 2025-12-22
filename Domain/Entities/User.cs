
using Domain.Enums;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; } 

        public ICollection<Enrollment> Enrolments { get; private set; }
        public ICollection<Course> Courses { get; private set; }
        public ICollection<PrivateMessage> SentMessages { get; private set; }
        public ICollection<PrivateMessage> RecievedMessages { get; private set; }
        private User()
        {
            
        }
        public User(string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Email = email;
            PasswordHash = passwordHash;
            Role = Role.Student;
            Enrolments = new List<Enrollment>();
        }
        public void ChangeRole(Role newRole)
        {
            Role = newRole;
        }

    }
}
