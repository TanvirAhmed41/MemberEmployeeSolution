using System.Data.Entity;
using MemberEmployee.Models.Entities;

namespace MemberEmployee.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
