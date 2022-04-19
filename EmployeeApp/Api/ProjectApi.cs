using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Api
{
    public class ProjectApi
    {
        public static List<Project> GetProjects() 
            => Database.Projects;
    }
}
