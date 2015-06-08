using Day5.HollywoodPrinciple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.HollywoodPrinciple
{
    public class DynamicCallerDiscovery<T>
    {
        static IEnumerable<ICaller<T>> _rules = null;
        public IEnumerable<ICaller<T>> GetCallers()
        {
            if(_rules==null)
            {
                _rules = from type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(m => m.GetTypes())
                               where  typeof(ICaller<T>).IsAssignableFrom(type)
                               select (ICaller<T>)Activator.CreateInstance(type);                
            }
            return _rules;
        }
    }
}
