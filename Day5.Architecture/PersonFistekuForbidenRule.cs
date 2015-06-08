using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Architecture
{
    public class PersonFistekuForbidenRule: IRule<Person>
    {
        public bool Check(Person obj)
        {
            return obj.Surname.ToUpper() != "FISTEKU";
        }
    }
}
