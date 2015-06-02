using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            var doc = new XmlDocument();
            doc.Load("employee-instance.xml");

            var nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("a", "CompanyA");
            nsmgr.AddNamespace("b", "CompanyB");

            var node1 = doc.SelectSingleNode("/employees/a:employee", nsmgr);
            Console.WriteLine(node1.OuterXml);

            var node2 = doc.SelectSingleNode("/employees/b:employee", nsmgr);
            Console.WriteLine(node2.OuterXml);
        }
    }
}
