/** 
 * Ross Epstein
 * 12/10/2020
 * ADF119-O - APPLICATION DEVELOPMENT FUNDAMENTALS
 * 3.6 - Data Integration 2
 * **/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ADF_2011_EpsteinRoss
{
    class User
    {
        //create initial variables
        public string _name { get; set; }
        public int _id { get; set; }
        public int _status { get; set; }
        public string _state { get; set; }
        public string _city { get; set; }
        public string _password { get; set; }
        private static string[] userData;
        private static string matchedUser;

        private static readonly string filePath = "../../../Users.txt";

        //constructor
        public User(string name = "TestGuy", int id = 1, string password = "password", string city = "Default", string state = "NA", int status =  0)
        {
            //capture data for user object
            _name = name;
            _id = id;
            _password = password;
            _city = city;
            _state = state;
            _status = status;

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

            //create stream reader instance
            string line;
            using (StreamReader sr = new StreamReader(filePath))
            {
                matchedUser = "";
                //read until end of line
                while ((line = sr.ReadLine()) != null)
                {
                    /** determine if the username exists.  The | symbol
                     * will prevent instances of a partial username match.  IE:
                     * Josh will not trigger on Joshua.
                     * **/
                    if (line.Contains(_userName + "|"))
                    {
                        matchedUser = line;
                        
                    }
                }
            }

            //if matched user is not null
            switch (matchedUser != "")
            {
                case false:
                    break;
                case true:
                    //split userdate into parts
                    userData = matchedUser.Split('|');
                    break;

            }

            

            //insure username && password match based on pre-set array keys
            bool userFound = matchedUser != "" ? (_password == userData[2] && _userName == userData[0]) : false;

            //if the username and password are an exact match
            if (userFound)
            {
                //assign user data based on their space in the array
                user._name = userData[0];
                user._city = userData[3];
                user._state = userData[4];
                user._status = Int32.Parse(userData[5]);
            }

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
