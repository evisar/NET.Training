using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Tertigo.Service
{
    public class StaticMethodExecutor
    {
        public void ReturnResult(IHttpContextWriter contextWriter, object result, string requestContentType)
        {
            switch (requestContentType.ToUpperInvariant())
            {
                case "APPLICATION/JSON":
                    var jsser = new JavaScriptSerializer();
                    var jsresult = jsser.Serialize(result);
                    contextWriter.Write(jsresult);
                    break;
                case "TEXT/XML":
                    var xmlser = new XmlSerializer(result.GetType());
                    xmlser.Serialize(contextWriter.OutputStream, result);
                    break;
                default:
                    contextWriter.Write(result);
                    break;
            }
        }

        public object ExecuteStaticProperty(string method, string type)
        {
            var realType = Type.GetType(type);
            var realMethod = realType.GetProperty(method, BindingFlags.Public | BindingFlags.Static);
            var result = realMethod.GetValue(null, null);
            return result;
        }

        public Tuple<string, string> GetTypeAndMethod(string url)
        {
            if(string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Invalid url argument.");
            }
            url = url.Remove(0, 1);
            var tokens = url.Split('.');
            var method = tokens.Last();
            var type = "";
            for (int i = 0; i < tokens.Length - 1; i++)
            {
                type += tokens[i];
                if (i < tokens.Length - 2)
                {
                    type += ".";
                }
            }

            if (string.IsNullOrEmpty(method))
            {
                throw new ArgumentException("Invalid method argument.");
            }

            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException("Invalid type argument.");
            }

            return new Tuple<string, string>(type, method);
        }
    }
}