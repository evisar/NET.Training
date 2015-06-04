using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3.UnitTesting
{
    public class FileLogger: ILogger
    {
        public void Log(Guid id, string text)
        {
            File.WriteAllText(text + ".log", string.Format("Payment {0} succeeded.", id));
        }

        public void Log()
        {

        }
    }
}
