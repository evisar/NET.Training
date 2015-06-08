using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day5.Architecture
{
    public interface IRule<T>
    {
        bool Check(T obj);
    }
}
