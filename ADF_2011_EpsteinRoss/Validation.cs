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
    class Validation
    {


        //check if valid int
        public static bool CheckInt(string intCheck)
        {
            bool isItInt = int.TryParse(intCheck, out _);
            return (isItInt);
        }

        //check if int in range
        public static bool CheckRange(int num, int maxNum)
        {
            bool isInRange = (num > 0 && num <= maxNum);
            return (isInRange);
        }


        //check to insure valid string
        public static bool CheckString(string stringCheck)
        {
            bool stringValid = (stringCheck.Length > 0) && (!String.IsNullOrWhiteSpace(stringCheck));
            return (stringValid);
        }



    }
}
