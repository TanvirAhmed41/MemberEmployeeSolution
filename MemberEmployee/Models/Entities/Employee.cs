using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberEmployee.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
    }
}