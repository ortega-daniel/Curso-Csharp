using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; } = false;

        public override string ToString()
        {
            StringBuilder result = new();
            result.AppendLine($"{Date:d}");
            result.AppendLine($"{Hours}hrs on: {Database.Projects.Find(project => project.Id == ProjectId)?.Name}");
            result.AppendLine(Description);
            result.AppendLine("=======================================================");
            return result.ToString();
        }
    }
}
