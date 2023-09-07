
using Microsoft.EntityFrameworkCore;

namespace StounXXI.Models
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
        }

        public DbSet<HR> HR { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Candidat> Candidates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacancy>()
                .HasOne(v => v.Department)
                .WithMany(d => d.Vacancies)
                .HasForeignKey(v => v.Department.Id);

        }

        internal List<Candidat> GetAllCandidates()
        {
            throw new NotImplementedException();
        }

        internal Candidat GetCandidateById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
