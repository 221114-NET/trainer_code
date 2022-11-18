namespace pokemonApp;

class Charmander : Pokemon, ICapturable
{

    int dexNumber = 4;

    string type = "fire";

    string[] abilities = {"ember", "flamethrower"};

    public void Sound(){
        Console.WriteLine("*charmander noises*");
    }
    
    public void isCaptured(){
        Console.WriteLine("I've been captured!");
    }




}