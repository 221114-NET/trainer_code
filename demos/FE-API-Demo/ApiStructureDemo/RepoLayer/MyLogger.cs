using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoLayer
{      
    public interface IMyLogger
    {
        void LogStuff(object o);
    }

    public class MyLogger : IMyLogger
    {
        public void LogStuff(object o)
        {
            Console.WriteLine($"{o} just happened!");
        }
    }
}