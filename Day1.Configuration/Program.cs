using ConsoleApplication4.Configurations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                            
namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {

            var scm = new StandardConfigurationManager();
            var hrservice = new HRService();
            scm.LoadConfiguration(hrservice);
        }
    }
}
