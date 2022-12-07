using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoLayer
{
    public class YourOwnPersonalException : Exception
    {
        public string message { get; set; } = "Your own personal exception was fired.";
        public YourOwnPersonalException()
        {

        }
    }
}