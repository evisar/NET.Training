using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    public class HRService : IConfigurableComponent
    {
        public Uri Address { get; set; }

        string IConfigurableComponent.ConfigurationSection
        {
            get
            {
                return "hrservice";
            }
        }

        public System.Configuration.ConfigurationSection Configuration { get; set; }
    }
}
