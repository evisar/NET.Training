using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Day3.UnitTesting
{
    public class XmlFileService : Day3.UnitTesting.IXmlFileService
    {
        public virtual DateTime SaveFile(XmlDocument xml, string filename)
        {
            using (var xw = XmlWriter.Create(filename))
            {
                xml.WriteContentTo(xw);
            }

            var fileTime = File.GetCreationTimeUtc(filename);
            return fileTime;
        }

        public virtual XmlDocument ReadFile(string filename)
        {
            var xml = new XmlDocument();
            xml.Load(filename);
            return xml;
        }
    }
}
