namespace pokemonApp;

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

    //Auto-property syntax. This creates a backing field, along with the getter and setter. 
    public int dexNumber {get; set;}
    
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
    public void Sound()
    {
        Console.WriteLine("*pokemon noises*");
    }

    //Overriding
    //The keyword "override" tells the compiler to over-ride a method from the parent class.
    //in this case, we have a method ToString() inherited from the System.Object class.
    //and we have written our own implementation. 
    public override string ToString()
    {
        return $"My name is {name}, number {dexNumber}. I'm a {type} I am a pokemon.";
    }

}