namespace StackDemo;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        //instantiate a stack!
        StackO stack1 = new StackO();
        Person p = new Person("Martin", "Brody", "We're gonna need a bigger boat...");
        stack1.Push(p);
        Person p1 = new Person("Anakin", "Skywalker", "Luke, I am your father.");
        stack1.Push(p1);
        Person p2 = new Person("T", "100", "I'll be bahhhk.");
        stack1.Push(p2);

        stack1.StackTrace();

        Person p3 = stack1.PopPerson();
        while (p3 != null)
        {
            Console.WriteLine($"The popped person is {p3.Fname} {p3.Lname}");
            p3 = stack1.PopPerson();
        }

        Person p4 = new Person("Tony", "STACK", "I am Ironman");
        stack1.Push(p4);

        Person p5 = stack1.Peek();
        Console.WriteLine($"The peeked person is {p5.Fname} {p5.Lname}");
    }
}
