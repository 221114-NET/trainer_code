namespace StackDemo
{
    public class StackNode
    {

        public StackNode(Person p)
        {
            this.Person = p;
        }

        public StackNode Next { get; set; }
        public Person Person { get; set; }



    }
}