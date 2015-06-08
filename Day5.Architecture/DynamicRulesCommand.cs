using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Architecture
{
    public abstract class DynamicRulesCommand<T>: ICommand<T>
    {
        public abstract void Execute(T argument);

        public IEnumerable<IRule<T>> Rules
        {
            get
            {
                return (new DynamicRuleDiscovery<T>()).GetRules();
            }
        }
    }
}
