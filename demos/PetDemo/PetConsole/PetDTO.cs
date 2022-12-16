namespace PetConsole.App
{
    public class PetDTO
    {
        //fields
        public string name { get; set; }
        public string species { get; set; }
        public string coloring { get; set; }
        public int age { get; set; }

        public PetDTO() {}
        public PetDTO(string _name, string _species, string _coloring, int _age)
        {
            this.name = _name;
            this.species = _species;
            this.coloring = _coloring;
            this.age = _age;
        }
    }
}