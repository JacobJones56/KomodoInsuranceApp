using Developer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperRepo
{
    public class DeveloperRepository
    {

        private List<Developers> _listOfDevelopers = new List<Developers>();
        private int _devIdCounter = default;
        // Create
        public void CreateNewDeveloper(Developers developer)
        {
            developer.Id = ++_devIdCounter;
            _listOfDevelopers.Add(developer);
        }
        // Read
        public List<Developers> GetDeveloperDirectory()
        {
            return _listOfDevelopers;
        }
        // Update
        public bool UpdateExistingDeveloper(int originalId, Developers newId) 
        {
            Developers oldId = GetByIdDevelopers(originalId);

            if (oldId != null)
            {
                oldId.FirstName = newId.FirstName;
                oldId.LastName = newId.LastName;
                oldId.Age = newId.Age;
                oldId.Pluralsight = newId.Pluralsight;
               // oldId.Id = newId.Id;
               // oldId.TeamName = newId.TeamName;
                return true;
            }
            else 
            {
                return false;
            }
        }
               
        // Delete
        public bool RemoveDeveloperFromList(int id) 
        {
            Developers developer = GetByIdDevelopers(id);

            if (developer == null) 
            {
                return false;
            }

            int count = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);

            if (count > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Helper method

        public Developers GetByIdDevelopers(int id)
        {
            
            foreach (Developers developers in _listOfDevelopers) 
            {
                if (developers.Id == id) 
                {
                    return developers;
                }
            }
            return null;
        }

    }
}