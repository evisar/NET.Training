using Day5.HollywoodDependency;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day5.HollywoodPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var appSettings = ConfigurationManager.AppSettings;
            var objects = from key in appSettings.AllKeys
                        let type = Type.GetType(appSettings[key])
                        select Activator.CreateInstance(type);

            foreach (var obj in objects)
            {
                HollywoodCall(obj);
            }
        }

        private static void HollywoodCall(object obj)
        {
            var callerDiscType = typeof(DynamicCallerDiscovery<>).MakeGenericType(obj.GetType());
            dynamic callerDisc = Activator.CreateInstance(callerDiscType);
            var callers = callerDisc.GetCallers();

            foreach (var caller in callers)
            {
                var mi = (MethodInfo)caller.GetType().GetMethod("Call");
                mi.Invoke(caller, new object[] {obj});
                //caller.Call(obj);
            }
        }
    }
}
