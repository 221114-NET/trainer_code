﻿
// create a space at line 1 ^^^, then r-click > refactor to add in the Main method and namespace.
// we need to create the delegate globally so that the class has access to it.
// create a class wtih methods that we can assign to that delegate.
// envoke the RegularMethod() with the delegate.

namespace delegatedemo
{
    public class Program
    {
        public delegate string MarksDelegateType(int x, string y);
        public delegate void MarksDelegateType1(Person p, int x, string y);


        public static void Main(string[] args)
        {
            MarksDelegateType mdt = MethodClass.AppendString;
            string result = DelegateClass.RegularMethod(mdt, 5, "Mark is kewl...");
            // Console.WriteLine(result);

            MarksDelegateType mdt1 = MethodClass.ConverIntToString;
            string result1 = DelegateClass.RegularMethod(mdt1, 5, "Mark is kewl...");
            // Console.WriteLine(result1);

            // create the delegate so that i can assign some matching methods to it and multicast
            MarksDelegateType1 mdt2 = MethodClass.ChangePerson;
            mdt2 += MethodClass.ChangePerson2;

            Person p = new Person();

            DelegateClass.EnvokeDelRegularMethod(p, 100, "ginnie", mdt2);
            Console.WriteLine($"The first name is =>{p.Fname} and the last naem is => {p.Lname}");


        }
    }
}




