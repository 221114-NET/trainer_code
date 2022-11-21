using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpsV1
{
    public static class RpsService
    {
        /// <summary>
        /// Take the users string choice and varify that the choice is valid:ROCK, PAPER, SCISSORS
        /// Returns 1 if ROCK, 2 if PAPER, 3 if SCISSORS. Otherwise -1.
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        public static int ValidateUserChoice(string choice)
        {
            //check that the choice matches either rock, paper, or SCISSORS
            if (choice.Equals("ROCK"))
            {
                return 1;
            }
            else if (choice.Equals("PAPER"))
            {
                return 2;
            }
            else if (choice.Equals("SCISSORS"))
            {
                return 3;
            }
            else return -1;
        }
    }
}