// using System.Numberics;

namespace rpsV1;
class Program
{
    //public int myglobalint { get; set; } = 1;// it's considered bad practice toi hav eglobal variables. It's also a security risk.

    static void Main(string[] args)
    {
        Random rand = new Random();
        Console.WriteLine("Hello, World!");

        // first, just have the values.
        int rock = 1;
        int paper = 2;
        int scissors = 3;

        // V2 - then refactor to use a collection.

        // welcome the user
        Console.Write("Hello, \n");
        Console.Write("Welcome to Rock-");
        Console.Write("Paper-Scissors");
        Console.WriteLine();

        // V2 make a do/while loop to keep playing the game (depending on user desire) after a game ends.

        //present the three choices and how to input user choice

        // get the users input
        // error check the input
        // string? userInput = Console.ReadLine();
        //Console.WriteLine($"The user inputted - {userInput}");

        //here we will compare the input to the ex[ected string values, then assign the value to it's corresponding string.
        //int isRock = String.Compare(userInput, 0, "ROCK", 0, 4);
        int userChoice = -1;
        while (userChoice < 0)
        {
            Console.WriteLine("Please enter:\n\tROCK,\n\tPAPER, \n\tSCISSORS");
            userChoice = RpsService.ValidateUserChoice(Console.ReadLine());
            if (userChoice < 0)
            {
                Console.WriteLine($"Hey, bub.. that's not a valid choice.");
            }

            Choices usersEnumChoice = (Choices)userChoice;
            Console.WriteLine($"The user chose {usersEnumChoice}");
        }

        // Challenge - finish out this code section to validate the users input is ROCK or PAPER or SCISSORS.
        // then assign the correct int to the choice.


        #region 
        //add validatoni in V2
        // int userInt = 0;
        // try
        // {
        //     userInt = Int32.Parse(userInput);
        // }
        // catch (FormatException ex)// catch a most specific exception first
        // {
        //     Console.WriteLine($"The first exception was - {ex.Message}");
        //     // here is where you log the exception to a file to use for diagnostics later.
        // }
        // catch (Exception ex)// catch the least specific exception last.
        // {
        //     Console.WriteLine($"The second exception was - {ex.Message}");
        //     //Console.WriteLine("inside the exception catch block.");
        // }
        // Console.WriteLine("Number 5 is ALIVE!");
        #endregion

        // NOW validate user input
        int userInt = 0;// will hold the users int-validated input
        /** 
        tryParse will try to conver the 1st arg into an int. 
        If it's successful, it will return TRUE and place 
        the value into the out variable
        */
        //bool userInputValidated = Int32.TryParse(userInput, out userInt);


        // generate the computers random choices
        int compInt = rand.Next(1, 4);// 1st arg is incluxive, 2nd is exclusive.

        // compare the values with a switch statement?
        // this if statement is for if the user won the game
        if (userInt == 1 && compInt == scissors || userInt == 2 && compInt == rock || userInt == 3 && compInt == paper)
        {
            //user won
            Console.WriteLine($"Congrats. You won with a {userInt} against the computers {compInt}");
        }
        else if (userInt == 1 && compInt == 2 || userInt == 2 && compInt == 3 || userInt == 3 && compInt == 1)
        {
            // computer won
            Console.WriteLine($"Too bad, so sad. You lost with a {userInt} against the computers {compInt}");
        }
        else
        {
            // there was a tie
            Console.WriteLine($"This game was a tie. You both chose {compInt}");
        }

        // determine the winner

        // print winner info

        // V2 - update players W/L record

        // V2 - ask to play again


    }
}
