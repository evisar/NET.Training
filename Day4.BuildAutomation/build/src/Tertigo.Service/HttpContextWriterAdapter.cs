using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tertigo.Service
{
    public class HttpContextWriterAdapter: IHttpContextWriter
    {
        HttpContext _context;
        public HttpContextWriterAdapter(HttpContext context)
        {
            _context = context;
        }

        public void Write(object value)
        {
            _context.Response.Write(value);
        }

        public System.IO.Stream OutputStream
        {
            get { return _context.Response.OutputStream; }
        }
    }
}