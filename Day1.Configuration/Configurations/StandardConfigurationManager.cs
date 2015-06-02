using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4.Configurations
{
    public class StandardConfigurationManager
    {
        public void LoadConfiguration(IConfigurableComponent component)
        {
            var configuration = (ConfigurationSection)ConfigurationManager.GetSection(component.ConfigurationSection);
            component.Configuration = configuration;
        }
    }
}
