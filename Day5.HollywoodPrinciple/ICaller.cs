using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.HollywoodPrinciple
{
    public interface ICaller<T>
    {
        void Call(T obj);
    }
}
