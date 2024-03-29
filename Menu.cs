﻿/** 
 * Ross Epstein
 * 12/10/2020
 * ADF119-O - APPLICATION DEVELOPMENT FUNDAMENTALS
 * 3.6 - Data Integration 2
 * **/

using System;
using System.Collections.Generic;
using System.Text;

namespace ADF_2011_EpsteinRoss
{
    class Menu
    {

        //initialize menu variables
        private List<string> _menuItems { get; set; }
        public List<string> MenuList { get; set; }
        private string _title { get; set; }
        public static int menuLength = 0;

        public Menu()
        {

        }

        //initialize the menu based on array of string
        public void Init(string[] initData)
        {
            menuLength = 0;
            List<string> newMenu = new List<string>();
            int i = 0;

            //get each item in array and add to menu
            foreach (string item in initData)
            {
                newMenu.Add(item);
                i++;
                menuLength++;
            }

            _menuItems = newMenu;
            MenuList = newMenu;
            _title = _menuItems[0];
        }

        public void Display(bool userLoggedIn, User _activeUser)
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            if (!userLoggedIn)
            {
                App.Header($"{_title.ToUpper()}");
            }

            //if user is logged in, display welcome message for user
            if (userLoggedIn)
            {
                App.Header($"WELCOME, {_activeUser._name.ToUpper()}");
            }
            int i = 1;

            if (!userLoggedIn && _menuItems.Contains("Show Profile"))
            {
                _menuItems.RemoveAll(x => x == "Show Profile");
            }

            //if a user is logged, remove Create User from menu list pre-iteration 
            if (userLoggedIn && _menuItems.Contains("Create User"))
            {
                _menuItems.RemoveAll(x => x == "Create User");
            }

            //if user is not logged in, remove DisplayUsers
            if (!userLoggedIn && _menuItems.Contains("Display Users"))
            {
                _menuItems.RemoveAll(x => x == "Display Users");
            }

            //display all items in _menuItems where the text != "main menu"
            foreach (var item in _menuItems)
            {
                if (item.ToLower() != "main menu")
                {

                    if (item.ToLower() == "login") 
                    {
                        string displayChoice = userLoggedIn ? "Logout" : "Login";
                        Console.WriteLine($"[{i}]:  {displayChoice}");
                    }

                    else
                    {
                        Console.WriteLine($"[{i}]:  {item}");
                    }

                    i++;
                }
            }

        }
    }
}
