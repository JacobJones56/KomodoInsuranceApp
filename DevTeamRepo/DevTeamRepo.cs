using DevTeam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamRepo
{
    public class DevTeamRepository
    {
        
        private List<DevTeams> _listOfDevTeams = new List<DevTeams>();
        private int _devTeamIdCounter = default;
        // Create
        public void CreateNewDevTeam(DevTeams devTeam) 
        {
            devTeam.TeamId = ++_devTeamIdCounter;
            _listOfDevTeams.Add(devTeam);
        }

        // Read
        public List<DevTeams> GetDevTeamsList() 
        {
            return _listOfDevTeams;
        }

        // Update
        public bool UpdateExistingDevTeam(int originalTeamId, DevTeams newTeamId)
        {
            DevTeams oldTeamId = GetDevTeams(originalTeamId);

            if (oldTeamId != null)
            {
                oldTeamId.TeamId = newTeamId.TeamId;
                oldTeamId.TeamName = newTeamId.TeamName;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool RemoveDevTeamFromList(int id)
        {
            DevTeams devTeams = GetDevTeams(id);

            if (devTeams == null)
            {
                return false;
            }
            int count = _listOfDevTeams.Count;
            _listOfDevTeams.Remove(devTeams);

            if (count > _listOfDevTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
       

        // Helper method
        public DevTeams GetDevTeams(int id) 
        {
            foreach (DevTeams devTeams in _listOfDevTeams) 
            {
                if (devTeams.TeamId == id) 
                {
                    return devTeams;
                }
            }
            return null;
        }

    }
}
