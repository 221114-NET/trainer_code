using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackDemo
{
    public class StackO
    {
        public StackO()
        {
        }

        private StackNode Top { get; set; } = null;
        public int Size { get; set; } = 0;

        public bool Push(Person p)// check if thres no items yet
        {
            StackNode s = new StackNode(p);
            if (this.Top == null)// if the stack is empty, add this node to the top and make sure it doesn't point to another node.
            {
                this.Top = s;
                this.Top.Next = null;
            }
            else
            {// if there is someting already in the stack, assign the top to this nodes next, and make the new node the top.
                s.Next = this.Top;
                this.Top = s;
            }
            return false;
        }


        public Person PopPerson()
        {
            if (this.Top != null)
            {
                Person p = this.Top.Person;
                this.Top = this.Top.Next;
                return p;
            }
            else return null;
        }


        public void StackTrace()
        {
            StackNode sn = this.Top;
            while (sn != null)
            {
                Console.WriteLine($"{sn.Person.Fname} {sn.Person.Lname} says '{sn.Person.CatchPhrase}'");
                sn = sn.Next;
                //this.Top = this.Top.Next;// this is destructive because you loose the reference to the actual data.
            }
        }


        public Person Peek()
        {
            return this.Top.Person;
        }
    }
}