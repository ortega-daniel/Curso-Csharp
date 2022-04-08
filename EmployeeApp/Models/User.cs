using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsSupervisor { get; set; }

        private static int userSeed = 1000;

        public User(string name, DateTime startDate) : this(name, startDate, false) { }

        public User(string name, DateTime startDate, bool isSupervisor)
        {
            Id = userSeed++;
            Name = name;
            StartDate = startDate;
            Username = Id.ToString();
            Password = Id.ToString();
            IsSupervisor = isSupervisor;
        }
    }
}
