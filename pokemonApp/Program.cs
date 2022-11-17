namespace pokemonApp;
class Program
{
    static void Main(string[] args)
    {
        //Object instantiation
        Pokemon charmander = new Pokemon("charmander");
        
        //You can use dot notation to access fields and methods available to an object of that class.
        charmander.type = "fire";
        
        //This is how you call an instance method. It "belongs to" objects of that class.
        //You must instantiate an object of that class to call it.
        charmander.IsPokemon();

        //This is how you call a Class/static method. It "belongs to" the class. You do not need 
        //to instantiate an object to call it. 
        Pokemon.Sound();

    }
}

class Pokemon 
{
    //Fields

    //Fields are private by default. This field was explicitly declared private.
    private string name;
    
    //This field is public. It was explicitely declared public. It can be accessed via dot-notation
    //from any object of this class.
    public string type;
    
    //This field is also private. When no access modifier is explicitly given, the compiler treats the
    //field as private.
    int hitpoints;
    int dexNumber;
    int weight;
    int level;

    //Constructors - Special methods used to instantiate or "create" an instance of a class.
    //You can have as many constructors as you need provided the signatures are different. 
    //This is a common example of method overloading. 
    public Pokemon()
    {

    }

    public Pokemon(string name)
    {
        this.name = name;
    }
    public Pokemon(string pokename, string type, int hp, int dex, int wt, int lvl)
    {   
        name = pokename;

        //When the name of a constructor argument and the name of a class field are the same,
        //"this.field" denotes the internal field, versus the argument that gets passed into the 
        //constructor
        this.type = type;
        hitpoints = hp;
        dexNumber = dex;
        weight = wt;
        level = lvl;
    }

    //Methods

    //This method is an instance method. It can be called by an object of class Pokemon using dot-notation.
    public void IsPokemon()
    {
        Console.WriteLine($"My name is {name}. I'm a {type} I am a pokemon.");
    }

    //This method is static. It can be called with dot-notation using the name of the class itself.  
    public static void Sound()
    {
        Console.WriteLine("*pokemon noises*");
    }
}
