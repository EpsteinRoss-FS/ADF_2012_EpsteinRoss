/** 
 * Ross Epstein
 * 11/23/2020
 * ADF119-O - APPLICATION DEVELOPMENT FUNDAMENTALS
 * 1.3 Project Initiation
 * **/


using System;

namespace ADF_2011_EpsteinRoss
{
    class Program
    {
        public static bool hasExited = false;

        static void Main()
        {
            //continue program till user exits
            while (!hasExited)
            {
                App app = new App();
            }
        }
    }
}

