using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Architecture
{
    public class DynamicRuleDiscovery<T>
    {
        static IEnumerable<IRule<T>> _rules = null;
        public IEnumerable<IRule<T>> GetRules()
        {
            if(_rules==null)
            {
                _rules = from type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(m => m.GetTypes())
                               where  typeof(IRule<T>).IsAssignableFrom(type)
                               select (IRule<T>)Activator.CreateInstance(type);                
            }
            return _rules;
        }
    }
}
