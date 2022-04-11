using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class WorkLog
    {
        public bool IsApproved { get; set; } = false;
        public List<LogEntry> Entries { get; set; } = new();
    }
}
