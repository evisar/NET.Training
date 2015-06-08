using Day5.HollywoodDependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.HollywoodPrinciple
{
    public class ServiceConfigurator: ICaller<Service>
    {
        public void Call(Service obj)
        {
            if(obj.Legacy)
            {
                ///apply legacy addres
            }
            else
            {
                obj.Url = new Uri( "http://localhost/newendpoint");
            }
        }
    }
}
