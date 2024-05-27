using University.Models;
using Microsoft.EntityFrameworkCore;

namespace University.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext()
        {
        }

        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

       

        #region Pack
        public DbSet<StudentOrganization> StudentOrganizations { get; set; }
        public DbSet<AthleticsFacility> AthleticsFacilities { get; set; }
        public DbSet<Exam> Exams { get; set; }

        #endregion



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("UniversityDb");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region StudentSubject
            modelBuilder.Entity<Subject>().Ignore(s => s.IsSelected);

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "Wieńczysław", LastName = "Nowakowicz", PESEL = "PESEL1", BirthDate = new DateTime(1987, 05, 22) },
                new Student { StudentId = 2, Name = "Stanisław", LastName = "Nowakowicz", PESEL = "PESEL2", BirthDate = new DateTime(2019, 06, 25) },
                new Student { StudentId = 3, Name = "Eugenia", LastName = "Nowakowicz", PESEL = "PESEL3", BirthDate = new DateTime(2021, 06, 08) });

            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, Name = "Matematyka", Semester = "1", Lecturer = "Michalina Warszawa" },
                new Subject { SubjectId = 2, Name = "Biologia", Semester = "2", Lecturer = "Halina Katowice" },
                new Subject { SubjectId = 3, Name = "Chemia", Semester = "3", Lecturer = "Jan Nowak" }
            );
            #endregion

            #region Pack

            #region StudentOrganization
            modelBuilder.Entity<StudentOrganization>().HasData(
                  new StudentOrganization
                  {
                      StudentOrganizationId = 1,
                      Name = "Student Organization 1",
                      Advisor = "Advisor 1",
                      President = "President 1",
                      Description = "Description of Student Organization 1",
                      MeetingSchedule = "Weekly",
                      Email = "org1@example.com"
                  },
                  new StudentOrganization
                  {
                      StudentOrganizationId = 2,
                      Name = "Student Organization 2",
                      Advisor = "Advisor 2",
                      President = "President 2",
                      Description = "Description of Student Organization 2",
                      MeetingSchedule = "Bi-weekly",
                      Email = "org2@example.com"
                  },
                  new StudentOrganization
                  {
                      StudentOrganizationId = 3,
                      Name = "Student Organization 3",
                      Advisor = "Advisor 3",
                      President = "President 3",
                      Description = "Description of Student Organization 3",
                      MeetingSchedule = "Monthly",
                      Email = "org3@example.com"
                  }
           );


            #endregion

            #region AthleticsFacility


            modelBuilder.Entity<AthleticsFacility>().HasData(
                new AthleticsFacility
                {
                    AthleticsFacilityId = 1,
                    Name = "Athletics Facility 1",
                    Location = "Location 1",
                    Type = "Type 1",
                    Description = "Description of Athletics Facility 1",
                    Capacity = 100
                },
                new AthleticsFacility
                {
                    AthleticsFacilityId = 2,
                    Name = "Athletics Facility 2",
                    Location = "Location 2",
                    Type = "Type 2",
                    Description = "Description of Athletics Facility 2",
                    Capacity = 150
                },
                new AthleticsFacility
                {
                    AthleticsFacilityId = 3,
                    Name = "Athletics Facility 3",
                    Location = "Location 3",
                    Type = "Type 3",
                    Description = "Description of Athletics Facility 3",
                    Capacity = 200
                }
            );


            #endregion

            #region Exam

            modelBuilder.Entity<Exam>().HasData(
            new Exam
            {
                ExamId = 1,
                CourseCode = "MATH101",
                Date = new DateTime(2024, 6, 10),
                StartTime = new TimeSpan(9, 0, 0),
                EndTime = new TimeSpan(12, 0, 0),
                Location = "Room 101",
                Description = "Final Exam for Mathematics 101",
                Professor = "Dr. Johnson"
            },
            new Exam
            {
                ExamId = 2,
                CourseCode = "BIO202",
                Date = new DateTime(2024, 6, 12),
                StartTime = new TimeSpan(10, 0, 0),
                EndTime = new TimeSpan(13, 0, 0),
                Location = "Room 201",
                Description = "Midterm Exam for Biology 202",
                Professor = "Dr. Smith"
            },
            new Exam
            {
                ExamId = 3,
                CourseCode = "CHEM303",
                Date = new DateTime(2024, 6, 15),
                StartTime = new TimeSpan(11, 0, 0),
                EndTime = new TimeSpan(14, 0, 0),
                Location = "Room 301",
                Description = "Final Exam for Chemistry 303",
                Professor = "Dr. Brown"
            }
);


            #endregion

            #endregion

        }
    }
}
