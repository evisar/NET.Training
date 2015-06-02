using System;
using System.Configuration;
namespace ConsoleApplication4
{
    public interface IConfigurableComponent
    {
        string ConfigurationSection { get; }

        ConfigurationSection Configuration { get; set; }
    }
}
