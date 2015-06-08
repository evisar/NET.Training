using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Architecture
{
    public class CommandExecution
    {
        public void Execute<TCommand, TObject>(TCommand arg, TObject obj)
            where TCommand: ICommand<TObject>
        {
            //security
            //apply rules
            var isValid = arg.Rules.All(r => r.Check(obj));
            if(!isValid)
            {
                throw new InvalidOperationException("Validation failed.");
            }
            arg.Execute(obj);
        }
    }
}
