namespace MemberEmployee.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        // Foreign Key for Member
        public int MemberId { get; set; }  // This should match the `Id` column in `Members` table

        // Navigation property
        public virtual Member Member { get; set; }

    }
}