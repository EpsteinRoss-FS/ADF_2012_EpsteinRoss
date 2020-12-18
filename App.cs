/** 
 * Ross Epstein
 * 12/10/2020
 * ADF119-O - APPLICATION DEVELOPMENT FUNDAMENTALS
 * 3.6 - Data Integration 2
 * **/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ADF_2011_EpsteinRoss
{
    class App
    {
        private static Menu _appMenu { get; set; }
        private static User _activeUser { get; set; }
        private static bool _loggedIn { get; set; }
        private static readonly string filePath = "../../../Users.txt";
        public App()
        {
            //create initial menu
            Console.Clear();
            Menu appMenu = new Menu();
            string[] menuItems = { "Main Menu", "Create User", "Show Profile", "Login", "About","Display Users", "Exit" };
            _appMenu = appMenu;

            //initialize menu
            appMenu.Init(menuItems);

            appMenu.Display(_loggedIn, _activeUser);

            Selection();
        }

        public static void Selection()
        {
            //get the length of the menu - 1 to account for "Main Menu"
            int menuLength = Menu.menuLength - 1;
            Console.Write("Please make a selection >  ");
            string _userChoice = Console.ReadLine();

            //validate the choice is an integer
            bool isInt = Validation.CheckInt(_userChoice);
            int _userChoiceInt = isInt ? Int32.Parse(_userChoice) : 000;

            //validate the choice is in range of the menu
            bool isInRange = Validation.CheckRange(_userChoiceInt, menuLength);

            //ask again if the validation returns false
            while (!isInt || !isInRange)
            {
                Console.Clear();
                _appMenu.Display(_loggedIn, _activeUser);
                Console.Write($"Invalid entry!  Please enter a number between 1 and {menuLength} > ");
                _userChoice = Console.ReadLine();
                isInt = Validation.CheckInt(_userChoice);
                _userChoiceInt = isInt ? Int32.Parse(_userChoice) : 000; ;
                isInRange = Validation.CheckRange(_userChoiceInt, (menuLength));
            }

            //get the text value from the menu index based on user choice
            string chosenItem = _appMenu.MenuList[_userChoiceInt];

            //switch statement to handle the chosen menu item
            switch (chosenItem.ToLower())
            {
                case "create user":
                    Create();
                    break;
                case "about":
                    About();
                    break;
                case "login":
                    Login();
                    break;
                case "exit":
                    Exit();
                    break;
                case "show profile":
                    ShowProfile();
                    break;
                case "display users":
                    DisplayUsers();
                    break;
                default:
                    break;
            }
        }

        //call for the user login method
        public static bool Login()
        {
            //if a user is logged in, log user out
            if (_loggedIn)
            {
                _loggedIn = false;
                return _loggedIn;
            }

            //if user is not logged in, log in the user
            if (!_loggedIn)
            {
                if (_activeUser == null)
                {
                    _activeUser = new User();
                }

                _loggedIn = User.Login(_activeUser);

                return _loggedIn;
            }
            return _loggedIn;
        }

        //function for centering headers
        public static void Header(string headerName)
        {
            Console.WriteLine("========================================");

            string SpacedHeader;
            string paddingSpaces = "";
            int HeaderLength = headerName.Length;

            headerName = headerName.ToUpper();

            //40 is the length of "=" in header lines
            int totalSpaces = 40;

            //calculate 40 - lenstring / 2 for each sides padding
            int paddingEachSide = (totalSpaces - HeaderLength) / 2;

            //add padding to each side of the string
            for (int i = 0; i < paddingEachSide;)
            {
                paddingSpaces += " ";
                i++;
            }

            SpacedHeader = paddingSpaces + headerName + paddingSpaces;

            Console.WriteLine(SpacedHeader);

            Console.WriteLine("========================================");

        }

        //display the about section
        public static void About()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Header("WELCOME TO MY CONSOLE APPLICATION!");
            Console.WriteLine("This console application is a demonstration of my skillset in C#.\nIt is being done for my \"PROJECT AND PORTFOLIO I: APPLICATION DEVELOPMENT FUNDAMENTALS\"\n" +
                "class at Full Sail University!\n\nThis application demonstrates my ability to write C# code that utilizes:" +
                "\n  -  File I/O Functionality" +
                "\n  -  User Authentication" +
                "\n  -  User Creation" +
                "\n  -  Validation" +
                "\n  -  Automation (headers are auto spaced)" +
                "\n  -  Git Principles" +
                "\n  -  Agile Development Principles" +
                "\n\nI hope you enjoy it! - Ross Epstein");
            Continue();
        }

        //gracefully exit
        public static void Exit()
        {
            Console.WriteLine("Exiting...");
            Program.hasExited = true;
            return;
        }

        public static void DisplayUsers() 
        {
            Console.Clear();
            App.Header("Display Users");
            Console.WriteLine("\nThe following users were found:");
            List<string> usersToDisplay = User.DisplayUsers();
            int i = 1;
            
            foreach (var userName in usersToDisplay) 
            {
                Console.WriteLine($"{i}: {userName.ToUpper()}");
                i++;
            }
            Console.WriteLine("\n");
            Continue();
        }

        //display continue statement and wait for key press
        public static void Continue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void Create()
        {
            Console.Clear();
            Console.Write($"Please enter your desired username:  > ");
            string _chooseUserName = Console.ReadLine();
            bool validUsername = Validation.CheckString(_chooseUserName);

            //insure username is valid string
            while (!validUsername)
            {
                Console.Clear();
                Console.Write($"Invalid Entry!  ");
                Console.Write($"Please enter your desired username:  > ");
                _chooseUserName = Console.ReadLine();
                validUsername = Validation.CheckString(_chooseUserName);
            }

            Console.Write("Please enter your desired password:  > ");
            string _choosePassword = Console.ReadLine();
            bool validPassword = Validation.CheckString(_choosePassword);

            //insure password is valid string
            while (!validPassword)
            {
                Console.Clear();
                Console.Write($"Invalid Entry!  ");
                Console.Write($"Please enter your desired password:  > ");
                _choosePassword = Console.ReadLine();
                validPassword = Validation.CheckString(_choosePassword);
            }


            Console.Write("Please enter your desired city:  > ");
            string _chooseCity = Console.ReadLine();
            bool validCity = Validation.CheckString(_choosePassword);

            //insure city is a valid string
            while (!validCity)
            {
                Console.Clear();
                Console.Write($"Invalid Entry!  ");
                Console.Write($"Please enter your desired password:  > ");
                _chooseCity = Console.ReadLine();
                validCity = Validation.CheckString(_chooseCity);
            }

            Console.Write("Please enter your desired city:  > ");
            string _chooseState = Console.ReadLine();
            bool validState = Validation.CheckString(_choosePassword);

            //insure state is valid string
            while (!validState)
            {
                Console.Clear();
                Console.Write($"Invalid Entry!  ");
                Console.Write($"Please enter your desired password:  > ");
                _chooseState = Console.ReadLine();
                validState = Validation.CheckString(_chooseState);
            }


            //display choices and confirm they are correct
            Console.Clear();
            Console.WriteLine("You have chosen the following options:");
            Console.WriteLine($"Username: {_chooseUserName}");
            Console.WriteLine($"Password: {_choosePassword}");
            Console.WriteLine($"City: {_chooseCity}");
            Console.WriteLine($"Password: {_chooseState}");
            Console.WriteLine("Is this correct? Yes/No");
            
            //validate choice confirmation
            string confirmUser = Console.ReadLine();
            bool confirmChoiceValid = Validation.CheckString(confirmUser);
            
            while (!confirmChoiceValid || (confirmUser.ToLower() != "yes" && confirmUser.ToLower() != "no"))
            {
                Console.Clear();
                Console.WriteLine("Invalid entry!");
                Console.WriteLine("You have chosen the following options:");
                Console.WriteLine($"Username: {_chooseUserName}");
                Console.WriteLine($"Password: {_choosePassword}");
                Console.WriteLine($"City: {_chooseCity}");
                Console.WriteLine($"Password: {_chooseState}");
                Console.WriteLine("Is this correct? Yes/No");

                confirmUser = Console.ReadLine();
                confirmChoiceValid = Validation.CheckString(confirmUser);

            }

            if (confirmUser.ToLower() == "yes")
            {
                //generate a random user ID
                var rand = new Random();
                int userId = rand.Next(1, 2147483647);
                
                //all newly created users are active
                int userActive = 1;

                //setup streamwriter
                using (StreamWriter sw = File.AppendText(filePath)) { 

                    //write file
                    sw.WriteLine(_chooseUserName + "|" + userId + "|" + _choosePassword + "|" + _chooseCity + "|" + _chooseState + "|" + userActive + "");
                }
            }

            if (confirmUser.ToLower() == "no") 
            {
                Console.WriteLine("Cancelling user creation! Press any key to continue...");
                Console.ReadKey();
            }



        }

          public static void ShowProfile() 
        {
            Console.Clear();
            

            //display profile header
            Header($"USER { _activeUser._name.ToUpper()} PROFILE");

            //display user name
            Console.WriteLine($"NAME:  {_activeUser._name}");

            //display city and state
            Console.WriteLine($"STATE AND CITY:  {_activeUser._city}, {_activeUser._state} ");
            
            //display if they are active or not
            string userActive = _activeUser._status == 1 ? "Active" : "Inactive"; 
            Console.WriteLine($"ACCOUNT STATUS:  {userActive}");
            App.Continue();    
            
        }



    }
}
