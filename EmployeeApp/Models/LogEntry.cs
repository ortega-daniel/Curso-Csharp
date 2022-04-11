using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class LogEntry
    {
        public DateTime Date { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }
    }
}
