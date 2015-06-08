using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5.Architecture
{
    public interface ICommand<T>
    {
        void Execute(T argument);

        IEnumerable<IRule<T>> Rules { get; }
    }
}
