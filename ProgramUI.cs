using Developer;
using DeveloperRepo;
using DevTeam;
using DevTeamRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KomodoInsuranceApp
{
    class ProgramUI
    {
        
        private DeveloperRepository _developerRepo = new DeveloperRepository();
        private DevTeamRepository _devTeamRepo = new DevTeamRepository();
        //Info from Komodo Insurance:
        //Developers have names and ID numbers; we need to be able to identify one developer without mistaking them for another.
        //We also need to know whether or not they have access to the online learning tool: Pluralsight.
        //Teams need to contain their Team members(Developers) and their Team Name, and Team ID.
        //Our managers need to be able to add and remove members to/from a team by their unique identifier.
        //They should be able to see a list of existing developers to choose from and add to existing teams.
        //Odds are, the manager will create a team, and then add Developers individually from the Developer Directory to that team.

        //Challenge: Our HR Department uses the software monthly to get a list of all our Developers that need a Pluralsight license. Create this functionality in the Console Application

        //Challenge: Some of our managers are nitpicky and would like the functionality to add multiple Developers to a team at once, rather than one by one.Integrate this into your application.
        public void Run()
        {
            TestingDevelopers();
            MainProgram();
        }




        public void MainProgram()
        {
            
            bool Running = true;
            while (Running)
            {
                var unknownInput = "Invaild input please try again";

                Console.Clear();

                Console.WriteLine("Write a option and press enter\n" +
                    "1. Create new developer entry\n" +
                    "2. View list of all developers\n" +
                    "3. Create new development team entry\n" +
                    "4. View list of all development teams\n" +
                    "5. View list of developer IDs in use and Pluralsight access\n" +
                    "6. Delete developer\n" +
                    "7. Update developer\n" +
                    "11. Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateNewDeveloper();
                        break;
                    case "2":
                        ShowDevelopersList();
                        break;
                    case "3":
                        CreateNewDevTeam();
                        break;
                    case "4":
                        ShowDevTeamsList();
                        break;
                    case "5":
                        GetIdList();
                        break;
                    case "6":
                        DeleteDeveloper();
                        break;
                    case "7":
                        UpdateDeveloper();
                        break;
                    case "8":
                        GetDevTeamId();
                        break;
                    case "9":
                        AddDeveloperToDevTeam();
                        break;
                    case "10":
                        RemoveDeveloperFromDevTeam();
                        break;
                    case "11":
                        Console.WriteLine("GoodBye!");
                        Thread.Sleep(1000);
                        return;
                    default:
                        Console.WriteLine(unknownInput);
                        break;
                }




                Console.ReadKey();
            }
        }

        private void TestingDevelopers()
        {
            Developers developerTest = new Developers();
            developerTest.FirstName = "Jacob";
            developerTest.LastName = "Jones";
            developerTest.Age = 21;
            developerTest.Pluralsight = true;
            
            

            Developers developerTest1 = new Developers();
            developerTest1.FirstName = "New";
            developerTest1.LastName = "Person";
            developerTest1.Age = 22;
            developerTest1.Pluralsight = false;
            _developerRepo.CreateNewDeveloper(developerTest);
            _developerRepo.CreateNewDeveloper(developerTest1);
        }


        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developers developerInfo = new Developers();
            // First name
            Console.WriteLine("Please input a first Name");
            developerInfo.FirstName = Console.ReadLine();
            // Last name
            Console.WriteLine("Please input a last name");
            developerInfo.LastName = Console.ReadLine();
            // Age
            Console.WriteLine("Please input a age");
            developerInfo.Age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please press y to get this developer access to Pluralsight\n" +
               "any other input will result in no access for user");
            ConsoleKeyInfo info1 = Console.ReadKey();
            if (info1.Key == ConsoleKey.Y)
            {
                developerInfo.Pluralsight = true;
            }
            _developerRepo.CreateNewDeveloper(developerInfo);
            Console.WriteLine("");
            Console.WriteLine("Please press enter to leave or y to continue inputing entrys");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Enter)
            {
                MainProgram();
            }
            if (info.Key == ConsoleKey.Y)
            {
                CreateNewDeveloper();
            }
        }

        private void CreateNewDevTeam()
        {
            Console.Clear();
            DevTeams devTeamInfo = new DevTeams();
            //Team name
            Console.WriteLine("Please write the name of the development team");
            devTeamInfo.TeamName = Console.ReadLine();
            _devTeamRepo.CreateNewDevTeam(devTeamInfo);
            
            
            Console.WriteLine("Please press enter to leave or y to continue inputting entrys");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Enter)
            {
                MainProgram();
            }
            if (info.Key == ConsoleKey.Y)
            {
                CreateNewDevTeam();
            }

        }

        private void ShowDevelopersList()
        {
            Console.Clear();
            foreach (Developers developers in _developerRepo.GetDeveloperList())
            {
                Console.WriteLine("----------------------");
                Console.WriteLine($"First Name. " + developers.FirstName);
                Console.WriteLine($"Last Name. " + developers.LastName);
                Console.WriteLine($"Age. " + developers.Age);
                Console.WriteLine($"Id Number. " + developers.Id);
                Console.WriteLine($"Developer has access to Pluralsight. " + developers.Pluralsight);
                Console.WriteLine("----------------------");

            }
            Console.WriteLine("Please press enter to continue");
        }

        private void ShowDevTeamsList()
        {
            Console.Clear();
            foreach (DevTeams devteam in _devTeamRepo.GetDevTeamsList())
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Development Team. " + devteam.TeamId + " " + devteam.TeamName);
                Console.WriteLine("----------------------");

            }
            Console.WriteLine("Please press enter to continue");
        }

        private void GetIdList()
        {
            Console.Clear();
            if (_developerRepo.GetDeveloperList().Count > 0)
            {

                Console.WriteLine("All ID numbers in use");
                foreach (Developers developers in _developerRepo.GetDeveloperList())
                {
                    Console.WriteLine("ID Number. " + developers.Id);
                    Console.WriteLine("Pluralsight access. " + developers.Pluralsight);
                    Console.WriteLine("Please press enter to continue");
                }

            }
            else
            {
                Console.WriteLine("There are no developers to get IDs from");
                Console.WriteLine("Would you like to add some?");
                Console.WriteLine("Please press enter to leave or y to input entrys");
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.Enter)
                {
                    MainProgram();
                }
                if (info.Key == ConsoleKey.Y)
                {
                    CreateNewDeveloper();
                }
            }

        }
        private void GetDevTeamId()
        {
            Console.Clear();
            if (_devTeamRepo.GetDevTeamsList().Count > 0)
            {

                Console.WriteLine("all ID numbers in use");
                foreach (DevTeams devTeams in _devTeamRepo.GetDevTeamsList())
                {
                    Console.WriteLine("ID Number. " + devTeams.TeamId);
                    Console.WriteLine("Team name. " + devTeams.TeamName);
                }

            }
            else
            {
                Console.WriteLine("There are no DevTeams to get IDs from");
                Console.WriteLine("Would you like to add some?");
                Console.WriteLine("Please press enter to leave or y to input entrys");
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.Enter)
                {
                    MainProgram();
                }
                if (info.Key == ConsoleKey.Y)
                {
                    CreateNewDevTeam();
                }
            }
        }
        private void DeleteDeveloper()
        {
            ShowDevelopersList();

            Console.WriteLine("Which of these developers would you like to delete?\n" +
                "Please use their ID number");
            int userInput = int.Parse(Console.ReadLine());

            bool delete = _developerRepo.RemoveDeveloperFromList(userInput);
            if (delete)
            {
                Console.WriteLine("Developer was successfully deleted");
            }
            else
            {
                Console.WriteLine("Developer could not be deleted");
            }
        }
        private void UpdateDeveloper()
        {
            ShowDevelopersList();

            Console.WriteLine("Which developer would you like to update?\n" +
                "Please use their ID to select them");

            int userInput = int.Parse(Console.ReadLine());

            Console.Clear();
            Developers developerInfo = new Developers();
            // First name
            Console.WriteLine("Please input a first Name");
            developerInfo.FirstName = Console.ReadLine();
            // Last name
            Console.WriteLine("Please input a last name");
            developerInfo.LastName = Console.ReadLine();
            // Age
            Console.WriteLine("Please input a age");
            developerInfo.Age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please press y to get this developer access to Pluralsight\n" +
               "any other input will result in no access for user");
            ConsoleKeyInfo info1 = Console.ReadKey();
            if (info1.Key == ConsoleKey.Y)
            {
                developerInfo.Pluralsight = true;
            }

            bool update = _developerRepo.UpdateExistingDeveloper(userInput, developerInfo);

            if (update)
            {
                Console.WriteLine("\nUpdate successfull");
            }
            else
            {
                Console.WriteLine("\nUpdate was not successfull");
            }
        }
        private void AddDeveloperToDevTeam()
        {
            GetDevTeamId();

            Console.WriteLine("Which DevTeam would you like to add a developer to?\n" +
                "Please use the ID number of the team to select");
            int userInput = int.Parse(Console.ReadLine());

            DevTeams devTeams = _devTeamRepo.GetDevTeams(userInput);
            
            GetIdList();

            Console.WriteLine("Which developer would you like to add to this DevTeam?\n" +
                "Please use the ID number of the team to select");
            int userInput2 = int.Parse(Console.ReadLine());

            Developers developer = _developerRepo.GetDevelopers(userInput2);
            //Developers developer = default; 
            devTeams.AddDevelopersToDevTeam(developer);

        }
        private void RemoveDeveloperFromDevTeam()
        {
            GetDevTeamId();

            Console.WriteLine("Which DevTeam would you like to remove a developer from?\n" +
                "Please use the ID number of the team to select");
            int userInput = int.Parse(Console.ReadLine());

            DevTeams devTeams = _devTeamRepo.GetDevTeams(userInput);

            GetIdList();

            Console.WriteLine("Which developer would you like to remove from this DevTeam?\n" +
                "Please use the ID number of the team to select");
            int userInput2 = int.Parse(Console.ReadLine());

            Developers developer = _developerRepo.GetDevelopers(userInput);

            devTeams.RemoveDevelopersFromDevTeam(developer);

        }
        private void DisplayTeams()
        {
            DevTeams devTeams
        }
    }
}
