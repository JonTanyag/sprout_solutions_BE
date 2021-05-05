using sprout.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprout.data.Entity
{
    public class Employee
    {
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string TIN { get; set; }
        public double BasicSalary { get; set; }
        public double NetSalary { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
