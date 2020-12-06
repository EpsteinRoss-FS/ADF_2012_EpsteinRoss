﻿/** 
 * Ross Epstein
 * 12/05/2020
 * ADF119-O - APPLICATION DEVELOPMENT FUNDAMENTALS
 * 2.6 - Data Integration
 * **/

using System;
using System.Collections.Generic;
using System.Text;

namespace ADF_2011_EpsteinRoss
{
    class App
    {
        private static Menu _appMenu { get; set; }
        private static User _activeUser { get; set; }
        private static bool _loggedIn { get; set; }
        public App()
        {
            //create initial menu
            Console.Clear();
            Menu appMenu = new Menu();
            string[] menuItems = { "Main Menu", "Create User", "Login", "About", "Exit" };
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

            Console.Clear();
            Console.WriteLine("You have chosen the following options:");
            Console.WriteLine($"Username: {_chooseUserName}");
            Console.WriteLine($"Password: {_choosePassword}");
            Console.WriteLine("Is this correct? Yes/No");
            
            string confirmUser = Console.ReadLine();
            bool confirmChoiceValid = Validation.CheckString(confirmUser);
            
            while (!confirmChoiceValid || (confirmUser.ToLower() != "yes" && confirmUser.ToLower() != "no"))
            {
                Console.Clear();
                Console.WriteLine("Invalid entry!");
                Console.WriteLine("You have chosen the following options:");
                Console.WriteLine($"Username: {_chooseUserName}");
                Console.WriteLine($"Password: {_choosePassword}");
                Console.WriteLine("Is this correct? Yes/No");

                confirmUser = Console.ReadLine();
                confirmChoiceValid = Validation.CheckString(confirmUser);

            }

            if (confirmUser.ToLower() == "yes")
            {
                _activeUser = new User(_chooseUserName, 1 , _choosePassword);
            }
            if (confirmUser.ToLower() == "no") 
            {
                Console.WriteLine("Cancelling user creation! Press any key to continue...");
                Console.ReadKey();
            }



        }

    }
}