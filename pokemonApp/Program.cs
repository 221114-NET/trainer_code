namespace pokemonApp;

class Program
{
    static void Main(string[] args)
    {
        //Object instantiation
        //Pokemon charmander = new Pokemon("charmander");
        Pokemon squirtle = new Pokemon("squirtle");
        Charmander myCharmander = new Charmander();
        //Dependency inversion *sneak peak*. Your object depends on an abstraction. 
        ICapturable captured = new Charmander();

        //You can use dot notation to access fields and methods available to an object of that class.
        //charmander.type = "fire";
        //charmander.dexNumber = 4;
        //Console.WriteLine(charmander.ToString());
        //Console.WriteLine(squirtle.ToString());
        
        //This is how you call an instance method. It "belongs to" objects of that class.
        //You must instantiate an object of that class to call it.
        //charmander.IsPokemon();

        //This is how you call a Class/static method. It "belongs to" the class. You do not need 
        //to instantiate an object to call it.
        //squirtle.Sound(); 
        
        myCharmander.Sound();
        myCharmander.isCaptured();
        captured.isCaptured();

    }
}





