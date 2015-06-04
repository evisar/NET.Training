using System;
namespace Day3.UnitTesting
{
   public interface IXmlFileService
    {
        System.Xml.XmlDocument ReadFile(string filename);
        DateTime SaveFile(System.Xml.XmlDocument xml, string filename);
    }
}
