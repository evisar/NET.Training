using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Day2.Cryptography
{
    class XmlSignatureRsa
    {
        public static void Example()
        {
            var doc = new XmlDocument();
            doc.LoadXml("<payment id='1' from='Filan Fisteku' to='Fistek Filani'/>");

            var key = new RSACryptoServiceProvider();

            var xmldsig = new SignedXml(doc);
            xmldsig.AddReference(new Reference("#1"));
            xmldsig.SigningKey = key;

            xmldsig.ComputeSignature();


            var xmlSignature = xmldsig.Signature.GetXml().OuterXml;
        }
    }
}
