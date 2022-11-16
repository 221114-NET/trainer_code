// using System.Numberics;

namespace rpsV1;
class Program
{
    public int myglobalint { get; set; } = 1;// it's considered bad practice toi hav eglobal variables. It's also a security risk.
    static void Main(string[] args)
    {
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
        Console.WriteLine("Please enter:\n\t1 for ROCK,\n\t2 for PAPER, \n\t3 for SCISSORS");

        // get the users input
        // error check the input
        string? userInput = Console.ReadLine();
        Console.WriteLine(userInput);

        try
        {
            int userInt = Int32.Parse(userInput);
        }
        catch (FormatException ex)// catch a most specific exception first
        {
            Console.WriteLine($"The first exception was - {ex.Message}");
            // here is where you log the exception to a file to use for diagnostics later.
        }
        catch (Exception ex)// catch the least specific exception last.
        {
            Console.WriteLine($"The second exception was - {ex.Message}");
            //Console.WriteLine("inside the exception catch block.");
        }

        Console.WriteLine("Number 5 is ALIVE!");


        // generate the computers random choices



        // compare the values with a switch statement?
        // maybe throw an exception?

        // determine the winner

        // print winner info

        // V2 - update players W/L record

        // V2 - ask to play again













    }
}
