/** 
 * Ross Epstein
 * 11/23/2020
 * ADF119-O - APPLICATION DEVELOPMENT FUNDAMENTALS
 * 1.3 Project Initiation
 * **/

using System;
using System.Collections.Generic;
using System.Text;

namespace ADF_2011_EpsteinRoss
{
    class App
    {

        private static Menu _appMenu { get; set; }
        private static User _mainUser { get; set; }
        public App()
        {
            //create initial menu
            Console.Clear();
            Menu appMenu = new Menu();
            string[] menuItems = { "Main Menu", "Login", "About", "Exit" };
            _appMenu = appMenu;

            //initialize menu
            appMenu.Init(menuItems);

            //pass user for login
            User user = new User("TestGuy", 1, "password");

            _mainUser = user;

            appMenu.Display();
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
                _appMenu.Display();
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
                case "about":
                    About();
                    break;
                case "login":
                    Login();
                    break;
                case "exit":
                    Exit();
                    break;
                default:
                    break;
            }





        }

        //call for the user login method
        public static bool Login()
        {
            bool loggedIn = User.Login(_mainUser);
            return loggedIn;
        }

        //display the about section
        public static void About()
        {
            Console.Clear();
            Console.WriteLine("This is the about section.");
            Continue();
        }

        //gracefully exit
        public static void Exit()
        {
            Console.WriteLine("Exiting...");
            Program.hasExited = true;
            return;
        }

        //display continue statement and wait for key press
        public static void Continue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}
