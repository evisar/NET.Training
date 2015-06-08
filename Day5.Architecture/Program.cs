using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Architecture
{
    class Program
    {
        static void Main(string[] args)
        {
            var exec = new CommandExecution();
            var person = new Person { Forename = "Filan", Surname = "Fisteku", Age=20 };
            exec.Execute<SavePersonCommand, Person>(new SavePersonCommand(), person);
        }
    }
}
