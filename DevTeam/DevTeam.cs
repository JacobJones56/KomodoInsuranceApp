using Developer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam
{
    public class DevTeams
    {
       
        public List<Developers> DevelopersOnDevTeam { get; set; }
        public string TeamName { get; set; }
        public int TeamId { get; set; }
        

        public DevTeams() 
        {
            DevelopersOnDevTeam = new List<Developers>();
        }
        public DevTeams(string teamName, int teamId) 
        {
            TeamName = teamName;
            TeamId = teamId; 
            DevelopersOnDevTeam = new List<Developers>();
           
        }

        /*public void AddDevelopersToDevTeam(Developers developer)
        {
            this.DevelopersOnDevTeam.Add(developer);
        }
        public void RemoveDevelopersFromDevTeam(Developers developer)
        {
            this.DevelopersOnDevTeam.Remove(developer);
        }*/

    }
}
