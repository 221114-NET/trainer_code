using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace delegatedemo
{
    public static class MethodClass
    {
        public static string AppendString(int myInt, string myString)
        {
            for (int a = 0; a < myInt; a++)
            {
                myString += myString;
            }
            return myString;
        }

        public static string ConverIntToString(int myInt, string myString)
        {
            return myString + " " + myInt;
        }

        public static void ChangePerson(Person p, int q, string w)
        {
            p.Fname = w;
            p.Lname = q.ToString();
        }

        public static void ChangePerson2(Person p, int q, string w)
        {
            p.Fname += w;
            p.Lname += q.ToString();
        }



    }
}