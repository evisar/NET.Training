using Day5.HollywoodDependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.HollywoodPrinciple
{
    public class PersonCaller: ICaller<Person>
    {
        public void Call(Person person)
        {
            person.Loaded = DateTime.Now;
        }
    }
}
