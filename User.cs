/** 
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
    class User
    {
        //create initial variables
        public string _name { get; set; }
        public int _id { get; set; }
        public string _password { get; set; }
        private static readonly string filePath = "../../../Users.txt";

        //constructor
        public User(string name = "TestGuy", int id = 1, string password = "password")
        {
            //capture data for user object
            _name = name;
            _id = id;
            _password = password;

        }

        //Login method
        public static bool Login(User user)
        {
            Console.Clear();
            Console.Write($"Please enter your username:  > ");
            string _userName = Console.ReadLine();
            bool validUsername = Validation.CheckString(_userName);

            //insure username is valid string
            while (!validUsername)
            {
                Console.Clear();
                Console.Write($"Invalid Entry!  ");
                Console.Write($"Please enter your username:  > ");
                _userName = Console.ReadLine();
                validUsername = Validation.CheckString(_userName);
            }

            Console.Write("Please enter your password:  > ");
            string _password = Console.ReadLine();
            bool validPassword = Validation.CheckString(_password);

            //insure password is valid string
            while (!validPassword)
            {
                Console.Clear();
                Console.Write($"Invalid Entry!  ");
                Console.Write($"Please enter your password:  > ");
                _password = Console.ReadLine();
                validPassword = Validation.CheckString(_password);
            }

            //insure username && password match
            bool userFound = (_password == user._password && _userName == user._name);

            /**
             * if userFound returns false, user is not logged in.  If userFound
             * returns true, user is logged in.  True or False returned based on 
             * userFound.
             * **/
            string loginAttemptMsg = userFound ? "User found" : "User login not recognized";
            Console.WriteLine(loginAttemptMsg);
            App.Continue();

            return userFound;
        }

    }
}
