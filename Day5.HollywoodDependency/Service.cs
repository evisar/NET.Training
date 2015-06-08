using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.HollywoodDependency
{
    public class Service
    {
        public bool Legacy { get; set; }
        public Uri Url { get; set; }

        public bool EnableDiagnostics { get; set; }
    }
}
