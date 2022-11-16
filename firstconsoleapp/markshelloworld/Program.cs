namespace markshelloworld;

class Program
{
    //the main method is the entry point of every C# program
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Mark!");
        int x = MyFunc(5);// you call a Method with arguments
        Console.WriteLine(x);
    }

    /// <summary>
    /// This method will take an int and return that int +1
    /// </summary>
    /// <param name="one"></param>
    /// <returns></returns>
    static int MyFunc(int one)// a method has parameters
    {
        int xx = ++one;
        return xx;
    }
}
