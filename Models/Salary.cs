using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrifindoToys.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public DateTime CycleStartDate { get; set; }
        public DateTime CycleEndDate { get; set; }
        public int AbsentDays { get; set; }
        public int OTHours { get; set; }
        public decimal NoPayValue { get; set; }
        public decimal BasePayValue { get; set; }
        public decimal GrossPayValue { get; set; }
    }
}
