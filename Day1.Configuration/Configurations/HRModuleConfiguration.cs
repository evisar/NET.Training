using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4.Configurations
{
    public class HRModuleConfiguration: ConfigurationElement
    {
        [ConfigurationProperty("name")]
        public string Name 
        { 
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }
    }
}
