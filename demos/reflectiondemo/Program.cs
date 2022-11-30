
using System.Reflection;
using ModelsLayer;

internal class Program
{
    public int MarksMomsAge { get; set; } = 70;
    public string MarksMomsName { get; set; } = "Darlene";
    public int zipcode = 76028;

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        PokemonClass poke = new PokemonClass("MarksPokemon", "fucia", 12, 10);

        // TYpe class in the "medium of exchange" for Reflection.
        Program p = new Program();
        // Type programType = p.GetType();
        Type programType = typeof(Program);

        MemberInfo[] mbrArr = programType.GetMembers();
        foreach (var x in mbrArr)
        {
            Console.WriteLine($"{x.Name} - {x.DeclaringType}");
            if (x.Name.Equals("get_MarksMomsAge"))
            {
                MethodInfo mi = (MethodInfo)x;
                var x1 = mi.GetMethodBody();
                Console.WriteLine(x1.MaxStackSize);
            }
        }

        var assembly = programType.Assembly;
        Console.WriteLine($"{assembly.GetName().FullName}");

        var fields = programType.GetFields();
        foreach (var x in fields)
        {
            var xx = x.Attributes;
            x.SetValue(p, 76011);
            Console.WriteLine($"{xx.ToString()}'s value is now {x.GetValue(p)}");
        }


        FieldInfo fi = programType.GetField("zipcode", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)!;
        if (fi != null)
        {
            Console.WriteLine($"Name - {fi.Name}, value - {fi.GetValue(p)}, fieldhandle - {fi.FieldHandle}, ifFamilt,etc - {fi.IsFamilyOrAssembly}");
        }
        else
        {
            Console.WriteLine($"Dude, fi was null...");
        }
    }
}
