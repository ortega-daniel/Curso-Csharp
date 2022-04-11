using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private static int projectSeed = 200;

        public Project(string name, string description)
        {
            Id = projectSeed++;
            Name = name;
            Description = description;
        }
    }
}
