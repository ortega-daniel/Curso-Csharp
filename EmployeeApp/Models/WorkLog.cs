using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class WorkLog
    {
        public bool Validated { get; set; } = false;
        public List<LogItem> Log { get; set; } = new();
    }
}
