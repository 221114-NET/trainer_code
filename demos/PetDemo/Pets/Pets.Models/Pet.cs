namespace Pets.Models
{
    public class Pet
    {
        //Fields
        public string Name { get; set; }
        public string Species { get; set; }
        public string Coloring { get; set; }
        public int Age { get; set; }

        //Constructor
        public Pet() { }
        public Pet(string name, string species, string coloring, int age)
        {
            Name = name;
            Species = species;
            Coloring = coloring;
            Age = age;
        }

        //Methods

    }
}