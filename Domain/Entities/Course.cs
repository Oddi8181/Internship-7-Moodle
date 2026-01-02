namespace Domain.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ProffesorId { get; set; }
        public User Proffesor { get; private set; }

        public ICollection<StudyMaterial> StudyMaterials { get; private set; }
        public ICollection<Notification> Notifications { get; private set; }
        public ICollection<Enrollment> Enrollments { get; private set; }


        private Course() { }
        public Course(string name, User proffesor)
        {
            Name = name;
            Proffesor = proffesor;
            ProffesorId = proffesor.Id;

            StudyMaterials = new List<StudyMaterial>();
            Notifications = new List<Notification>();
            Enrollments = new List<Enrollment>();

        }

        public void AddStudent(User student)
        {
            var enrollment = new Enrollment(student, this);
            enrollment.CreatedAt = DateTime.UtcNow;
            Enrollments.Add(enrollment);
        }
        public void AddMaterial(string name, string url)
        {
            var material = new StudyMaterial(name, url, this);
            material.CreatedAt = DateTime.UtcNow;
            StudyMaterials.Add(material);
        }
        public void AddNotification(string title, string content)
        {
            var notification = new Notification(title, content, this);
            notification.CreatedAt = DateTime.UtcNow;
            Notifications.Add(notification);
        }


    }
}