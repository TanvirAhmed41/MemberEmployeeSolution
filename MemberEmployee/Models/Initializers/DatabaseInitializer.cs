using System.Data.Entity;
using MemberEmployee.Models.Data; // Add this if it's not there
using System;
using MemberEmployee.Models.Entities;

namespace MemberEmployee.Models.Initializers
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // Add seed data if needed
           
            base.Seed(context);
        }
    }
}
