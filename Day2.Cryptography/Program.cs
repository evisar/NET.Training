using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Day2.Cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            //sender

            var doc = new XmlDocument();
            doc.LoadXml("<payment id='1' from='Filan Fisteku' to='Fistek Filani'/>");

            var cert = GetCertificate();

            var xmldsig = new SignedXml(doc);
            xmldsig.AddReference(new Reference("#1"));
            xmldsig.SigningKey = cert.PrivateKey;
            xmldsig.KeyInfo = new KeyInfo();
            xmldsig.KeyInfo.AddClause( new KeyInfoX509Data(cert));

            xmldsig.ComputeSignature();


            var xmlSignature = xmldsig.Signature.GetXml().OuterXml;


            var signatureOk = xmldsig.CheckSignature(cert, true);
            
        }

        private static X509Certificate2 GetCertificate()
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            var cert = store.Certificates.Find(
                X509FindType.FindBySubjectDistinguishedName,
                "CN=Visar.Elmazi",
                false)[0];
            return cert;
        }
    }
}
