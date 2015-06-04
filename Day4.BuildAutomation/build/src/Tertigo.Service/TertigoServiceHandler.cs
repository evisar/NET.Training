using System;
using System.Web;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Tertigo.Service
{
    public class TertigoServiceHandler: IHttpHandler
    {

        StaticMethodExecutor _methodExec;

        public TertigoServiceHandler(StaticMethodExecutor methodExec)
        {
            _methodExec = methodExec;
        }

        public TertigoServiceHandler()
        {
            _methodExec = new StaticMethodExecutor();
        }



        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var typeAndMethod = _methodExec.GetTypeAndMethod(context.Request.RawUrl);
            var type = typeAndMethod.Item1;
            var method = typeAndMethod.Item2;
            var result = _methodExec.ExecuteStaticProperty(method, type);
            var contextWriter = new HttpContextWriterAdapter(context);
            _methodExec.ReturnResult(contextWriter, result, context.Request.ContentType);        
        }

        
    }
}
