using Day5.HollywoodDependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.HollywoodPrinciple
{
    public class ServiceDiagnosticPolicy: ICaller<Service>
    {
        public void Call(Service obj)
        {
            obj.EnableDiagnostics = true;
        }
    }
}
