using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrifindoToys.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int MonthlySalary { get; set; }
        public int OTPerHour { get; set; }
        public int Allowances { get; set; }

    }
}
