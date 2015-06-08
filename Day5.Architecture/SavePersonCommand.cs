using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Architecture
{
    public class SavePersonCommand: DynamicRulesCommand<Person>
    {
        public override void Execute(Person argument)
        {
            
        }

    }
}
