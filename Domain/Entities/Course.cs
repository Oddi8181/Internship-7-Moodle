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
    }
}