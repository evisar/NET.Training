using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3.UnitTesting
{
    public interface ILogger
    {
        void Log(Guid id, string text);
        void Log();
    }
}
