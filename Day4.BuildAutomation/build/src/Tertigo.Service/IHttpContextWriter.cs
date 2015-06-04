using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tertigo.Service
{
    public interface IHttpContextWriter
    {
        void Write(object value);
        Stream OutputStream { get; }
    }
}
