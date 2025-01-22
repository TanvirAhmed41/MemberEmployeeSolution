using System;
using System.ComponentModel.DataAnnotations;

namespace MemberEmployee.Models.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public DateTime DateOfBirth { get; set; }
        
        public int? MemberId { get; set; }
        // Navigation property for one-to-one relationship
        public Employee Employee { get; set; }  // This defines the relationship with Employee
    }
}