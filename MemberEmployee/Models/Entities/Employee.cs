namespace MemberEmployee.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; } // Employee's name
        public string Position { get; set; } // Employee's job position
        public decimal Salary { get; set; } // Employee's salary
        public int MemberId { get; set; } // Foreign key to Member        

        public virtual Member Member { get; set; } // Navigation property
    }
     
}