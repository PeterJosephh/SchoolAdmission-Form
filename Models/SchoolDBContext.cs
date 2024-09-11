using Microsoft.EntityFrameworkCore;

namespace SchoolAdmission.Models
{
    public class SchoolDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<GuardianStudent> GuardianStudents { get; set; }
        public DbSet<Guardian> Guardians { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SchoolDatabase;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);

        }


    }
}
