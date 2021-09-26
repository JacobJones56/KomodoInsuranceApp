using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer
{
    public class Developers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
        public bool Pluralsight { get; set; }
        public string TeamName { get; set; }
        

        public Developers() { }

        public Developers(string firstName, string lastName, int age, int id, string teamName) 
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Id = id;
            TeamName = teamName;
        }
    }
}
