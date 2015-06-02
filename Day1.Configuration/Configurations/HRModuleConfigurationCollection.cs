using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4.Configurations
{
    public class HRModuleConfigurationCollection: ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new HRModuleConfiguration();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((HRModuleConfiguration)element).Name;
        }
    }
}
