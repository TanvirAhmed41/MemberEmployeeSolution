using System.Data.Entity;
using MemberEmployee.Models.Entities;

namespace MemberEmployee.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configuring one-to-one relationship
            modelBuilder.Entity<Member>()
                        .HasOptional(m => m.Employee)
                        .WithRequired(e => e.Member);

            base.OnModelCreating(modelBuilder);
        }
    }

}
